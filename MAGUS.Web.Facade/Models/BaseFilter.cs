using MAGUS.Web.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Web.Facade.Models
{
    public abstract class BaseFilter : IBaseFilter
    {
        public string OrderBy { get; set; }
        public bool Desc { get; set; }
        public int Limit { get; set; }
        public int Position { get; set; }
    }
}
