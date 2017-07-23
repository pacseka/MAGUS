using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Web.Facade.ExpressionBuilder
{
    struct TypePair
    {
        public Type SourceType { get; set; }
        public Type DestinationType { get; set; }

        public TypePair(Type sourceType, Type destinationType)
        {
            SourceType = sourceType;
            DestinationType = destinationType;
        }
    }
}
