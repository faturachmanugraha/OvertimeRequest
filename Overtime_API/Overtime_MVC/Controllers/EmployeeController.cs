using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Overtime_API.Models;
using Overtime_API.ViewModels;
using Overtime_MVC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Overtime_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient httpClient;

        public EmployeeController()
        {
            URL url = new URL();
            httpClient = new HttpClient
            { 
                BaseAddress = new Uri(url.GetDevelopment())
            };
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Entity
        public async Task<IActionResult> Get()
        {
            var header = Request.Headers["Authorization"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("Employee");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<Employee>>>(apiResponse);

            return new JsonResult(result);
        }

        public async Task<IActionResult> GetById(string NIK)
        {
            var response = await httpClient.GetAsync("Employee?NIK=" + NIK);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseVM<Employee>>(apiResponse);

            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            var header = Request.Headers["Authorization"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);
          
            var response = await httpClient.PostAsJsonAsync("Employee", employee);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Employee>(apiResponse);

            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Put(Employee employee)
        {
            var header = Request.Headers["Authorization"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.PutAsJsonAsync("Employee", employee);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseVM<Employee>>(apiResponse);
            
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string NIK)
        {
            using var response = await httpClient.DeleteAsync("Employee/" + NIK);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseVM<Employee>>(apiResponse);
            
            return Json(result);
        }
    }
}
