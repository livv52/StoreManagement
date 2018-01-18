using Service.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StoreManagement.Controllers
{
    [RoutePrefix("store")]
    public class StoreController : ApiController
    {
            private readonly IStoreRepository _storeRepo;

            public StoreController(IStoreRepository storeRepo)
            {
                _storeRepo = storeRepo;
            }

            [HttpGet]
            [Route("get/{id}")]
            public IHttpActionResult GetByID(int id)
            {
            var store = _storeRepo.Get(id);
                if (store == null)
                {
                    return NotFound();
                }
                return Ok(store);
            }

            [HttpGet]
            [Route("list")]
            public IHttpActionResult List()
            {
                var storeList = _storeRepo.List();
                if (storeList == null)
                {
                    return NotFound();
                }
                return Ok(storeList);
            }

            [HttpPost]
            [Route("insert")]
            public IHttpActionResult Insert(Store store)
            {
                var result = _storeRepo.Insert(store);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }

            [HttpPut]
            [Route("update")]
            public IHttpActionResult Update(Store store)
            {
                var result = _storeRepo.Update(store);
                return Ok(result);
            }

            [HttpDelete]
            [Route("delete/{id}")]
            public IHttpActionResult Delete(int id)
            {
                _storeRepo.Delete(id);
                return Ok();
            }

    }
}