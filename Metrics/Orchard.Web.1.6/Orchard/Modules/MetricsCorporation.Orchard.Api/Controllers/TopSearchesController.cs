using System;
using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class TopSearchesController : ApiController
    {
        private readonly ICrud<SearchLogModel> _service;
        private IHttpContextAccessor _accessor;
        public IOrchardServices Services { get; private set; }
        public Localizer T { get; set; }

        public TopSearchesController(IOrchardServices orchardServices, ICrud<SearchLogModel> service,IHttpContextAccessor accessor)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
            _accessor = accessor;
        }

        // GET api/topsearches
        public IEnumerable<SearchLogModel> Get()
        {
            var session = _accessor.Current().Session;
            if (session != null)
            {
                var currentUser = session["CurrentUser"] as UserModel;
                if (currentUser != null) return _service.GetAllById(currentUser.Id);
            }

            return null;
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
