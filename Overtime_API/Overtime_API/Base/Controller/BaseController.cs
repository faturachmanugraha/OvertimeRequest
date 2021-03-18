using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overtime_API.Repositories.Interfaces;

namespace Overtime_API.Base.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var result = repository.GetAll();
            if (result == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(new { status = HttpStatusCode.OK, result, message = "Data Ditemukan" });
        }

        [HttpGet("{key}")]
        public ActionResult<Entity> Get(Key key)
        {
            var result = repository.Get(key);
            if (result == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(new { status = HttpStatusCode.OK, result, message = "Data Ditemukan" });
        }


        [HttpPost]
        public ActionResult<Entity> Post(Entity entity)
        {
            var result = repository.Create(entity);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(new { status = HttpStatusCode.OK, result, message = "Data Telah Ditambahkan" });
        }

        [HttpPut]
        public ActionResult<Entity> Put(Entity entity)
        {
            var result = repository.Update(entity);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(new { status = HttpStatusCode.OK, result, message = "Data Telah Diganti" });
        }

        [HttpDelete("{key}")]
        public ActionResult<Entity> Delete(Key key)
        {
            var result = repository.Delete(key);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(new { status = HttpStatusCode.OK, result, message = "Data Telah Dihapus" });
        }
    }
}
