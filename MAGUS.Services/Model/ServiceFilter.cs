using MAGUS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Services.Model
{
    public class ServiceFilter<T>: IServiceFilter<T> where T: class
    {
        public Expression<Func<T, bool>> Filter { get; set; }
        public Expression<Func<T, object>> Sort { get; set; }
        public int? Limit { get; set; }
        public int? Position { get; set; }
        public bool Descending { get; set; }
    }
}
