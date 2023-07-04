using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core.Interface
{
    public interface IAnswerRepository
    {
        List<Answer> GetAllAnswer(int qesid);
        void add(Answer ins);
    }
}
