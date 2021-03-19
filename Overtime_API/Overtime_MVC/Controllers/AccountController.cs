using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Overtime_API.Models;
using Overtime_MVC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Overtime_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient httpClient;

        public AccountController()
        {
            URL url = new URL();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(url.GetDevelopment())
            };
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {
            var header = Request.Headers["Authorization"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.PostAsJsonAsync("Account", account);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Employee>(apiResponse);

            return new JsonResult(result);
        }

    }
}
