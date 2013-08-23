using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;

namespace MetricsCorporation.Controllers
{
    public class MasterIdController : ApiController
    {
        private readonly ICrud<MasterIdModel> _service;

        public MasterIdController(ICrud<MasterIdModel> service)
        {
            _service = service;
        }

        // GET api/masterid
        public IEnumerable<MasterIdModel> Get()
        {
            return _service.GetAll();
        }

        // GET api/masterid/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/masterid
        public MasterIdModel Post(MasterIdModel value)
        {
            if (ModelState.IsValid)
            {
                return _service.Create(value);
            }

            return null;
        }

        // PUT api/masterid/5
        public HttpResponseMessage Put(int id, MasterIdModel value)
        {
            if (ModelState.IsValid)
            {
                _service.Update(value);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        // DELETE api/masterid/5
        public HttpResponseMessage Delete(int id)
        {
            if (id == 0)
                return new HttpResponseMessage(HttpStatusCode.NotImplemented);

            _service.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
