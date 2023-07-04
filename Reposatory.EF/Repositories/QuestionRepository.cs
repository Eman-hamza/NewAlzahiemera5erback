using Model.core.Interface;
using Model.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reposatory.EF.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuesionRepository
    {
        private ApplicationDBContext context;
        public QuestionRepository(ApplicationDBContext context) : base(context)
        {
             this.context=context;
        }

        public List<Question> GetAllQuestions(int id)
        {
            List<Question> questions = context.questions.Where(e=>e.TestId==id).ToList();
            return questions;
        }
        public Test Test(int id)
        {
            Test test = context.Tests.Where(e => e.id == id).Include(e => e.questions).ThenInclude(a => a.Answers).FirstOrDefault();
            return test;
        }
    }
}
