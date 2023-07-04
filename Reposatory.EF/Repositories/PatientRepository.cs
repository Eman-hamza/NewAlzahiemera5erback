using Microsoft.EntityFrameworkCore;
using Model.core;
using Model.core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.EF.Repositories
{
    internal class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        ApplicationDBContext context;
        public PatientRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public Patient FindPatient(string Id)
        {
           Patient patient = context.patients.Where(e => e.Id == Id).Include(a => a.User).FirstOrDefault();
            return patient;
        }
    }
}
