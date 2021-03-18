using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Repositories.Interfaces
{
    interface IDapperRepository<Entity> where Entity : class
    {
        Entity ExecuteSP(string query, DynamicParameters parameters);
        IEnumerable<Entity> Get(string query, DynamicParameters parameters);
    }
}
