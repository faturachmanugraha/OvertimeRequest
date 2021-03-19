using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.ViewModels
{
    public class ResponseVM<Entity>
        where Entity : class
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public Entity Result { get; set; }
    }
}
