using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Service.DTOs;
using Service.Entities;
using Service.Interfaces;

namespace StoreManagement.Controllers
{
    [RoutePrefix("district")]
    public class DistrictController : ApiController
    {
        private readonly IDistrictRepository _districtRepo;

        public DistrictController(IDistrictRepository districtRepo)
        {
            _districtRepo = districtRepo;
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult GetByID(int id)
        {
            var district = _districtRepo.Get(id);
            if (district == null)
            {
                return NotFound();
            }
            return Ok(district);
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult List()
        {
            var districtList = _districtRepo.List();
            if (districtList == null)
            {
                return NotFound();
            }
            return Ok(districtList);
        }

        [HttpPost]
        [Route("insert")]
        public IHttpActionResult Insert(DistrictDTO districtDto)
        {
            var result = _districtRepo.Insert(districtDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(District district)
        {
            var result = _districtRepo.Update(district);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _districtRepo.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}/salesperson")]
        public IHttpActionResult GetSalesperson(int id)
        {
            var salesPersonList = _districtRepo.GetSalesperson(id);
            if (salesPersonList == null)
            {
                return NotFound();
            }
            return Ok(salesPersonList);
        }

        [HttpGet]
        [Route("{id}/stores")]
        public IHttpActionResult GetStores(int id)
        {
            var storeList = _districtRepo.GetStores(id);
            if (storeList == null)
            {
                return NotFound();
            }
            return Ok(storeList);
        }

        [HttpPost]
        [Route("addsp")]
        public IHttpActionResult AddSalesPerson(DistrictSalesPerson districtSalesPerson)
        {
            var result = _districtRepo.AddSalesPerson(districtSalesPerson);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deletesp/{id}")]
        public IHttpActionResult DeleteSalesPerson(int id)
        {
            _districtRepo.DeleteSalesPerson(id);
            return Ok();
        }
    }
}