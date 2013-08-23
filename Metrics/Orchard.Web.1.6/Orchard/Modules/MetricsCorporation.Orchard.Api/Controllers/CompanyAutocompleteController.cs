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



namespace MetricsCorporation.Orchard.Api.Controllers
{
    [System.Web.Http.Authorize]
    public class CompanyAutocomplete : ApiController
    {
        private readonly ICrud<CompanyAutocompleteModel> _service;


        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public CompanyAutocomplete(IOrchardServices orchardServices, ICrud<CompanyAutocompleteModel> service)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
        }


        [Queryable]
        public IQueryable<CompanyAutocompleteModel> Get(string str)
        {
            return ((CompanyAutocompleteService)_service).GetCompany(str).AsQueryable();
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
