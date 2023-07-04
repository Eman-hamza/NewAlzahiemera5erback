using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core.Interface
{
    public interface IPatientRepository
    {
       Patient FindPatient(string Id);
    }
}
