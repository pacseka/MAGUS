using MAGUS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Web.Facade
{
    public class StartApp
    {
        public static void InitConfigs()
        {
            InitMapConfig.CreateObjectMapping();
        }
    }
}
