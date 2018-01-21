using Service.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StoreManagement.Controllers
{
    [RoutePrefix("salesperson")]
    public class SalespersonController : ApiController
    {
        private readonly ISalespersonRepository _salespersonRepo;

        public SalespersonController(ISalespersonRepository salespersonRepo)
        {
            _salespersonRepo = salespersonRepo;
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult GetByID(int id)
        {
            var salesperson = _salespersonRepo.Get(id);
            if (salesperson == null)
            {
                return NotFound();
            }
            return Ok(salesperson);
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult List()
        {
            var salespersonList = _salespersonRepo.List();
            if (salespersonList == null)
            {
                return NotFound();
            }
            return Ok(salespersonList);
        }

        [HttpPost]
        [Route("insert")]
        public IHttpActionResult Insert(Salesperson salesperson)
        {
            var result = _salespersonRepo.Insert(salesperson);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(Salesperson salesperson)
        {
            var result = _salespersonRepo.Update(salesperson);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _salespersonRepo.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("districts/{id}")]
        public IHttpActionResult GetDistricts(int id)
        {
            var salespersonList = _salespersonRepo.GetDistricts(id);
            if (salespersonList == null)
            {
                return NotFound();
            }
            return Ok(salespersonList);
        }
    }
}