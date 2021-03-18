using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Overtime_API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Repositories
{
    public class GeneralDapperRepository<Entity> : IDapperRepository<Entity>
        where Entity : class
    {
        private readonly IConfiguration Configuration;
        private readonly IDbConnection Connection;
        public GeneralDapperRepository(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.Connection = new SqlConnection(Configuration.GetConnectionString("MyConnection"));
        }

        public Entity ExecuteSP(string query, DynamicParameters parameters)
        {
            Entity result;
            result = Connection.Query<Entity>(query, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public IEnumerable<Entity> Get(string query, DynamicParameters parameters)
        {
            return Connection.Query<Entity>(query, parameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
