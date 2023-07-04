using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.core;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Model.core.Interface;
using Elzahimer.DTO;

namespace Elzahimer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;


        public AccountController(IUnitOfWorkRepository unitOfWorkRepository, UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
            this.userManager = userManager;
            this.config = config;
        }
        [HttpPost("RegisterPatient")]//api/account/register
        public async Task<IActionResult> RegisterPatient([FromForm] RegisterPatientDTO userDTO)
        {
            Data Return = new Data();
            if (ModelState.IsValid)
            {
                using var dataStream = new MemoryStream();
                userDTO.image.CopyTo(dataStream);
                //create  ==>add user db
                ApplicationUser userModel = new ApplicationUser();
                userModel.Email = userDTO.email;
                userModel.UserName = userDTO.username;
                userModel.PhoneNumber = userDTO.phoneNumber;
                userModel.Country = userDTO.country;
                userModel.City = userDTO.city;
                userModel.gender = userDTO.gender;
                userModel.NationalId = userDTO.nationalId;
                userModel.Status = Status.Pending;
                userModel.image = dataStream.ToArray();


                IdentityResult result = await userManager.CreateAsync(userModel, userDTO.password);
                Patient patient= new Patient() ;
                patient.Id = userModel.Id;
                patient.bithDate=userDTO.bithDate;
                patient.Relative=userDTO.relative;
                patient.DeseasDiscription = userDTO.deseasDiscription;
                patient.diseaselevel = userDTO.diseaselevel;
                await unitOfWorkRepository.Patient.AddAsync(patient);

                if (result.Succeeded && userDTO.isPatient)
                {
                    await userManager.AddToRoleAsync(userModel, "IsPatient");

                    patient.IsPatient = true;
                    patient.IsHelper = false;

                    Return.IsPatient = true;
                    Return.Message = "Success";
                    Return.IsPass = true;
                    return Ok(userDTO);
                }
                else
                {
                    Return.Message = "Result not succesed pass not valid";
                    return Ok(Return);
                }
            }
            return Content("Not Vaild");
        }



        [HttpPost("RegisterHelper")]//api/account/register
        public async Task<IActionResult> RegisterHelper([FromForm] RegisterHelperDTO userDTO)
        { 
            Data Return = new Data();
            if (ModelState.IsValid)
            {
                using var dataStream = new MemoryStream();
                userDTO.image.CopyTo(dataStream);
                //create  ==>add user db
                ApplicationUser userModel = new ApplicationUser();
                userModel.Email = userDTO.email;
                userModel.UserName = userDTO.username;
                userModel.PhoneNumber = userDTO.phoneNumber;
                userModel.Country = userDTO.country;
                userModel.City = userDTO.city;
                userModel.gender = userDTO.gender;
                userModel.NationalId = userDTO.nationalId;
                userModel.Status = Status.Pending;
                userModel.image = dataStream.ToArray();


                IdentityResult result = await userManager.CreateAsync(userModel, userDTO.password);
                Helper helper = new Helper();
                helper.Id = userModel.Id;
                helper.PricePerHour = userDTO.pricePerHour;
                

                await unitOfWorkRepository.Helper.AddAsync(helper);

                if (result.Succeeded && userDTO.isHelper)
                {
                    await userManager.AddToRoleAsync(userModel, "IsHelper");
                    helper.IsPatient = false;
                    helper.IsHelper = true;

                    Return.IsPatient = false;


                    Return.Message = "Success";
                    Return.IsPass = true;
                    return Ok(Return);
                }
                else
                {
                    Return.Message = "Result not succesed pass not valid";
                    return Ok(Return);
                }
            }
            return Content("Not Vaild");
        }


        
        
        [HttpPost("Login")]
        public async Task<ActionResult<DataReturnLogin>> Login(LoginDTO loginDTO)
        {
            DataReturnLogin data = new DataReturnLogin();
            ApplicationUser usermodel = await userManager.FindByNameAsync(loginDTO.UserName);
            if (ModelState.IsValid && usermodel.Status==Status.Approval )
            {
                //check ....
               
                if (usermodel != null && await userManager.CheckPasswordAsync(usermodel, loginDTO.password))
                {
                    //create cliams
                    List<Claim> myclaim = new List<Claim>();
                    myclaim.Add(new Claim(ClaimTypes.NameIdentifier, usermodel.Id));
                    myclaim.Add(new Claim(ClaimTypes.Name, usermodel.UserName));
                    myclaim.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    List<string> role = (List<string>)await userManager.GetRolesAsync(usermodel);
                    if (role != null)
                    {
                        foreach (var claim in role)
                        {
                            myclaim.Add(new Claim(ClaimTypes.Role, claim));
                        }
                    }

                    //signingCredentials ---->( key , alg) in --> header

                    //key ==> (semantissecrtkey)

                    var authSecuritKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecrytKey"]));


                    SigningCredentials credentials =
                        new SigningCredentials(authSecuritKey, SecurityAlgorithms.HmacSha256);


                    //represent token
                    JwtSecurityToken mytoken = new JwtSecurityToken(
                        issuer: config["JWT:ValidIss"],
                        audience: config["JWT:ValidAud"],
                        expires: DateTime.UtcNow.AddDays(3),
                        claims: myclaim,
                        signingCredentials: credentials
                        );
                    //create token
                    return Ok(
                     new
                     {
                         token = new JwtSecurityTokenHandler().WriteToken(mytoken),

                     }

                     );

                    data.Message = "Success";
                    data.IsPass = true;

                    return Ok(usermodel);
                }
                else
                {
                    data.Message = "NotValid";
                    return Ok(usermodel);
                }
            }
            return Ok(usermodel);

        }

    }

}
