using Model.core.Interface;
using Model.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.EF.Repositories
{
    public class AnswerRepository : BaseRepository<Question>, IAnswerRepository
    {
        private ApplicationDBContext context;
        public AnswerRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public void add(Answer ins)
        {
           context.answers.Add(ins);
        }

        public List<Answer> GetAllAnswer(int qesid)
        {
            List<Answer> answers= context.answers.Where(e => e.QuestionID == qesid).ToList();
            return answers;
        }
    }
}
