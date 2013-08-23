using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;

namespace MetricsCorporation.Controllers
{
    [Authorize]
    public class EmployeeSizeController : ApiController
    {
        private readonly ICrud<EmployeeSizeModel> _service;

        public EmployeeSizeController(ICrud<EmployeeSizeModel> service)
        {
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
