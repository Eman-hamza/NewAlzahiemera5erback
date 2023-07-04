
using Elzahimer.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Model.core;
using Model.core.Interface;
using Reposatory.EF;
using Reposatory.EF.Repositories;
using System.Text;
using System.Text.Json.Serialization;

namespace Elzahimer
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddCors(options => {
                options.AddPolicy("MyPolicy", builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );

            });

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"),
               b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

            /*
                        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDBContext>();*/
            // Add services to the container.
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;

            }
            ).AddEntityFrameworkStores<ApplicationDBContext>();
            builder.Services.AddAuthentication(options =>
            {
                //jwt
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//not valid account
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    //parmeter
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIss"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAud"],
                    IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecrytKey"]))//asdZXCZX!#!@342352
                };
            })  //how to check if toke valid or not    
              ;
            builder.Services.AddSignalR();
            builder.Services.AddCors(
                options =>

                    options.AddDefaultPolicy(cong => {
                        cong.AllowAnyMethod().
                        SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader()
                        .AllowCredentials();

                    })
                );

            // Add services to the container.
            builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = " ITI Projrcy"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }

                    }
                });
            });


            builder.Services.AddSignalR();
            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();//images - sound - video -html -css -js
            app.UseCors("MyPolicy");//add header response Asscee-original-m
            app.MapHub<ChatHub>("/ChatHub");
            app.UseAuthentication();//AddAuth==>jwt 
            app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    endpoints.MapHub<ChatHub>("/chat");
            //});
            app.MapControllers();

            app.Run();
        }
    }
}