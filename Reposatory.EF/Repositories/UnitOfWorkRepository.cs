using System;
using Model.core.Crateria;
using Model.core.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Model.core;

namespace Reposatory.EF.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public ApplicationDBContext context;
        public IBaseRepository<ApplicationUser> ApplicationUser { get; private set; }

        public IBaseRepository<Alarm> Alarm { get; private set; }

        public IBaseRepository<Artical> Artical { get; private set; }

        public IBaseRepository<Helper> Helper { get; private set; }

        public IBaseRepository<HelperProposal> HelperProposal { get; private set; }

        public IBaseRepository<HelpRequest> HelpRequest { get; private set; }

        public IBaseRepository<Message> Message { get; private set; }

        public IBaseRepository<Patient> Patient { get; private set; }
        public IBaseRepository<Question> Question { get; private set; }

        public IBaseRepository<Test> Test { get; private set; }

        public IBaseRepository<Answer> Answer { get; private set; }
        public IArticalReposatory ArticalReposatory { get; private set; }
        public IPatientRepository PatientRepository { get; private set; }
        public IHelperRepository helperRepository { get; private set; }
        public IMessageRepository MessageRepository { get; private set; }

        public IQuesionRepository QuesionRepository { get; private set; }

        public UnitOfWorkRepository(ApplicationDBContext context)
        {
            this.context = context;
            ApplicationUser= new BaseRepository<ApplicationUser>(this.context);
            Alarm= new BaseRepository<Alarm>(this.context);
            Artical = new BaseRepository<Artical>(this.context);
            Helper= new BaseRepository<Helper>(this.context);
            HelperProposal= new BaseRepository<HelperProposal>(this.context);
            HelpRequest= new BaseRepository<HelpRequest>(this.context);
            Message= new BaseRepository<Message>(this.context);
            Patient= new BaseRepository<Patient>(this.context);
            Test= new BaseRepository<Test>(this.context);
            Question=new BaseRepository<Question>(this.context);
            Answer=new BaseRepository<Answer>(this.context);
            ArticalReposatory = new ArticalReposatory(this.context);
            PatientRepository=new PatientRepository(this.context);
            helperRepository= new HelperRepository(this.context);
            MessageRepository= new MessageRepository(this.context);
            QuesionRepository=new QuestionRepository(this.context);
        }

        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
