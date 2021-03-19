using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            return Ok(new { message = "Succes Login", Token = token });
        }

        [HttpPut("ChangePassword/{NIK}")]
        public IActionResult ChangePassword(string NIK, ChangePasswordVM changePasswordVM)
        {
            var result = accountRepository.ChangePassword(NIK, changePasswordVM.NewPassword);

            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(new { status = HttpStatusCode.OK, result, message = "Password Telah Diganti" });
        }
    }
}
