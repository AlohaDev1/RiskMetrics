using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Helpers;
using MetricsCorporation.Models;

namespace MetricsCorporation.Controllers
{
    [Authorize]
    public class TopSearchesController : ApiController
    {
        private readonly ICrud<SearchLogModel> _service;

        public TopSearchesController(ICrud<SearchLogModel> service)
        {
            _service = service;
        }

        // GET api/topsearches
        public IEnumerable<SearchLogModel> Get()
        {
            return _service.GetAllById(SessionHelper.CurrentUser.Id);
        }

        // GET api/topsearches/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/topsearches
        public void Post([FromBody]string value)
        {
        }

        // PUT api/topsearches/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/topsearches/5
        public void Delete(int id)
        {
        }
    }
}
