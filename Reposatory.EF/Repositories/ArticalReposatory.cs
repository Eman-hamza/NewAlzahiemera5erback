using Model.core;
using Model.core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.EF.Repositories
{
    public class ArticalReposatory :BaseRepository<Artical>, IArticalReposatory
    {

        ApplicationDBContext context;
        public ArticalReposatory(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }
        public List<Artical> GetByDate(DateTime date)
        {
            List<Artical> articals = context.Articals.Where(a => a.Date == date).OrderByDescending(d => d.Date).ToList();
            return articals;
        }

        public List<string> GetByDat(DateTime date)
        {
            List<string> articals = context.Articals.Where(a => a.Date == date).OrderByDescending(d=>d.Date).Select(e => e.tiltle).ToList();
            return articals;
        }


        public List<Artical> GetByTitle(string Title)
        {
           List<Artical> articals = context.Articals.Where(a=>a.tiltle==Title).ToList();
            return articals;
        }
    }
}
