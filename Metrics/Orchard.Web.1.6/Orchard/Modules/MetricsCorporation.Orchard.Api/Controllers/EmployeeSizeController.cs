using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;
using Orchard;
using Orchard.Localization;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class EmployeeSizeController : ApiController
    {
        private readonly ICrud<EmployeeSizeModel> _service;
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public EmployeeSizeController(IOrchardServices orchardServices, ICrud<EmployeeSizeModel> service)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
        }

        // GET api/employeesize
        public IEnumerable<EmployeeSizeModel> Get()
        {
            return _service.GetAll();
        }

        // GET api/employeesize/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/employeesize
        public void Post([FromBody]string value)
        {
        }

        // PUT api/employeesize/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/employeesize/5
        public void Delete(int id)
        {
        }
    }
}
