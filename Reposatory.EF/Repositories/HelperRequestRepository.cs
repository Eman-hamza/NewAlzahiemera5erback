using Model.core;
using Model.core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.EF.Repositories
{
    public class HelperRequestRepository : BaseRepository<HelpRequest>, IHelperRequestRepository
    {
        ApplicationDBContext context;
        public HelperRequestRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        //public List<HelpRequest> GetByRequestDate(DateTime date)
        //{
        //    List<string> Request = context.HelpRequests.Where(a => a.Date == date).OrderByDescending(d => d.Date).Select(e => e.Tiltle).ToList();
        //    return articals;
        //}
    }
}
