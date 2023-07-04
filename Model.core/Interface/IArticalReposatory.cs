using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core.Interface
{
    public interface IArticalReposatory
    {
        List<Artical> GetByTitle(string Title);
        List<Artical> GetByDate(DateTime date);

        List<string> GetByDat(DateTime date);

    }
}
