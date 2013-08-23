using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;

namespace MetricsCorporation.Controllers
{
    [Authorize]
    public class CountyController : ApiController
    {

        private readonly ICrud<CountyModel> _service;

        public CountyController(ICrud<CountyModel> service)
        {
            _service = service;
        }

        // GET api/county
        public IEnumerable<CountyModel> Get()
        {
            return _service.GetAll();
        }

        // GET api/county/5
        public string Get(string id)
        {
            return "value";
        }

        // POST api/county
        public void Post([FromBody]string value)
        {
        }

        // PUT api/county/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/county/5
        public void Delete(int id)
        {
        }
    }
}
