using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;
using Orchard;
using Orchard.Localization;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class CombController : ApiController
    {
        private readonly ICrud<CombModel> _service;

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public CombController(IOrchardServices orchardServices, ICrud<CombModel> service)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
        }

        // GET api/companies
        public IEnumerable<CombModel> Get()
        {
            return _service.GetAll();
        }

        // GET api/companies/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/companies
        public void Post([FromBody]string value)
        {
        }

        // PUT api/companies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/companies/5
        public void Delete(int id)
        {
        }
    }
}
