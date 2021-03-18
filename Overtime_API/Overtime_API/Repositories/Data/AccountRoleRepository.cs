﻿using Overtime_API.Context;
using Overtime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<MyContext, AccountRole, string>
    {
        public AccountRoleRepository(MyContext myContext) : base (myContext)
        {

        }
    }
}