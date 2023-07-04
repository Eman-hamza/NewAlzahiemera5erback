using Microsoft.EntityFrameworkCore.Migrations;
using Model.core.Crateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Model.core.Interface
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IBaseRepository<ApplicationUser> ApplicationUser { get; }
        IBaseRepository<Alarm> Alarm { get; }
        IBaseRepository<Artical> Artical { get; }
        IBaseRepository<Helper> Helper { get; }
        IBaseRepository<HelperProposal> HelperProposal { get; }
        IBaseRepository<HelpRequest> HelpRequest { get; }
        IBaseRepository<Message> Message { get; }     
        IBaseRepository<Patient> Patient { get; }
        IBaseRepository<Test> Test { get; }
        IBaseRepository<Answer> Answer { get; }
        IBaseRepository<Question> Question { get;}
        IArticalReposatory ArticalReposatory { get; }
        IHelperRepository  helperRepository { get; }
        IPatientRepository PatientRepository { get; }
        IMessageRepository MessageRepository { get; }
        IQuesionRepository QuesionRepository { get; }
    }
}
