using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Web.Facade.Interfaces
{
    public interface IBaseFilter
    {
        string OrderBy { get; set; }
        bool Desc { get; set; }
        int Limit { get; set; }
        int Position { get; set; }
    }
}
