using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overtime_API.Base.Controller;
using Overtime_API.Models;
using Overtime_API.Repositories.Data;

namespace Overtime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OvertimeDataController : BaseController<OvertimeData, OvertimeDataRepository, int>
    {
        public OvertimeDataController(OvertimeDataRepository overtimeDataRepository) : base(overtimeDataRepository)
        {

        }
    }
}
