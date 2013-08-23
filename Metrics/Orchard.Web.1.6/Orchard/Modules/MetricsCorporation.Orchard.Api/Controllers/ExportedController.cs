using System.Collections.Generic;
using System.Globalization;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class ExportedController : ApiController
    {
        private readonly ICrud<ExportedModel> _service;
        private readonly IHttpContextAccessor _accessor;

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public ExportedController(IOrchardServices orchardServices, ICrud<ExportedModel> service, IHttpContextAccessor accessor)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
            _accessor = accessor;
        }

        // GET api/companies
        public IEnumerable<ExportedModel> Get()
        {
            UserModel currentUser = null;
            var session = _accessor.Current().Session;
            if (session != null)
                    currentUser = session["CurrentUser"] as UserModel;

            if (currentUser != null)
            {
                return _service.GetAllById(int.Parse(currentUser.Id.ToString(CultureInfo.InvariantCulture)));
            }
            
            return null;
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
