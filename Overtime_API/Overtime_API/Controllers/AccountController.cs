using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Overtime_API.Base.Controller;
using Overtime_API.Models;
using Overtime_API.Repositories.Data;
using Overtime_API.Services;
using Overtime_API.ViewModels;

namespace Overtime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        private readonly IConfiguration Configuration;
        public AccountController(AccountRepository accountRepository, IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.Configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginVM loginVM)
        {
            var user = accountRepository.Login(loginVM);
            var jwt = new JwtService(Configuration);
            var token = jwt.GenerateSecurityToken(user);
            return Ok(new { message = "SuccesLogin", Token = token });


        }
    }
}
