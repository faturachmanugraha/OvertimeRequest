using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_MVC.Base
{
    public class URL
    {
        public string GetProduction()
        {
            return "https://localhost:44379/api/";
        }

        public string GetDevelopment()
        {
            return "https://localhost:44379/api/";
        }
    }
}
