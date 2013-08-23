using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;
using Orchard;
using Orchard.Localization;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using MetricsCorporation.Data;
using MetricsCorporation.Entities;
using System.Web.Http;





namespace MetricsCorporation.Orchard.Api.Controllers
{
    [System.Web.Http.Authorize]
    public class CarrierNameAutocomplete : ApiController
    {
        private readonly ICrud<CarrierNameAutocompleteModel> _service;


        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public CarrierNameAutocomplete(IOrchardServices orchardServices, ICrud<CarrierNameAutocompleteModel> service)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
        }

        [Queryable]
        public IQueryable<CarrierNameAutocompleteModel> Get()
        {
            return ((carrierNameAutocompleteService)_service).GetCarrier().AsQueryable();
        }

        [Queryable]
        public string GetResult(string id)
        {
            List<CarrierNameAutocompleteModel> Response = null;
            if (ModelState.IsValid)
            {
                Response = ((carrierNameAutocompleteService)_service).GetCarrierGroupAndName().ToList();
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
