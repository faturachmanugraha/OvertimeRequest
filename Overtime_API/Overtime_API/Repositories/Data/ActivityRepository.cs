﻿using Overtime_API.Context;
using Overtime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Repositories.Data
{
    public class ActivityRepository : GeneralRepository<MyContext, Activity, int>
    {
        public ActivityRepository(MyContext myContext) : base (myContext)
        {

        }
    }
}
