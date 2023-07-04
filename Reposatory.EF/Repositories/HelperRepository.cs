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
    public class HelperRepository : BaseRepository<Helper>, IHelperRepository
    {
        ApplicationDBContext context;
        public HelperRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context; 
        }

       
        public Helper FindHelper(string Id)
        {
           Helper helper = context.Helpers.Where(e => e.Id == Id).Include(a => a.User).FirstOrDefault();
            return helper;
        }
    }
}
