using Dapper;
using Microsoft.Extensions.Configuration;
using Overtime_API.Context;
using Overtime_API.Models;
using Overtime_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Repositories.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        private readonly GeneralDapperRepository<LoginVM> DapperRepository;
        public IConfiguration Configuration;
        public AccountRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.Configuration = configuration;
            this.DapperRepository = new GeneralDapperRepository<LoginVM>(configuration);
        }

        public LoginVM Login(LoginVM loginVM)
        {
            if (loginVM != null)
            {
                var spName = "SP_Login";
                parameters.Add("@email", loginVM.Email);
                parameters.Add("@password", loginVM.Password);
                var result = DapperRepository.ExecuteSP(spName, parameters);
                return result;
            }
            throw new ArgumentNullException();
        }
    }
}
