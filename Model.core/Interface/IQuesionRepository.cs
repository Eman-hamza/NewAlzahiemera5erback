using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core.Interface
{
    public interface IQuesionRepository
    {
        List<Question> GetAllQuestions(int id);
        Test Test(int id);
    }
}
