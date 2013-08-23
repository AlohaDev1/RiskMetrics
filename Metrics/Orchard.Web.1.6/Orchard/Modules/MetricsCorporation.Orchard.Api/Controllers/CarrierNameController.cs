using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using Orchard.Mvc;
using MetricsCorporation.Models;
using Orchard;
using Orchard.Localization;
using System.Text;
using MetricsCorporation.BL.Services;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class CarrierNameController : ApiController
    {
        private readonly ICrud<ClassCodeModel> _service;
        private readonly ICrud<CarrierNameAutocompleteModel> _serviceCarrierName;
        private readonly IHttpContextAccessor _accessor;
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public CarrierNameController(IOrchardServices orchardServices, ICrud<ClassCodeModel> service, ICrud<CarrierNameAutocompleteModel> carrierService, IHttpContextAccessor accessor)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
            _accessor = accessor;
            _serviceCarrierName = carrierService;
        }

        [HttpPost]
        public string Get(string id)
        {
            List<CarrierNameAutocompleteModel> Response = null;
            if (ModelState.IsValid)
            {

                UserModel currentUser = null;
                var session = _accessor.Current().Session;
                if (session != null)
                    currentUser = session["CurrentUser"] as UserModel;
                else
                    return "False";

                if (currentUser != null && currentUser.ShowCarrier)
                {
                    Response = ((carrierNameAutocompleteService)_serviceCarrierName).GetCarrierGroupAndName().ToList();

                    StringBuilder child = new StringBuilder();
                    StringBuilder parent = new StringBuilder();
                    var result = Response.GroupBy(co => co.CarrierGroup).Select(grp => grp.ToList()).ToList().OrderBy(p => p[0].CarrierGroup);

                    foreach (var carrierList in result)
                    {
                        if (carrierList.Count > 0)
                        {
                            foreach (var carrier in carrierList)
                            {
                                child.Append("{ data: '" + carrier.CarrierName + "', state:'closed' , attr: { id: '" + carrier.Id + "'} }" + ",");
                            }
                            child = child.Remove(child.Length - 1, 1);
                            //child = child.TrimEnd(',');
                            parent.Append("{ data: '" + carrierList[0].CarrierGroup + "', state:'closed' , attr: { id: '" + "parent_" + carrierList[0].Id + "', code : 'group' }, children: [" + child + "]}" + ",");
                            //child = string.Empty;
                            child.Clear();
                        }
                    }

                    //return "[" + parent.TrimEnd(',') + "]";
                    return "[" + parent.Remove(parent.Length - 1, 1) + "]";
                }
                else
                {
                    return "False";
                }
            }
            return null;

        }

        //// POST api/county
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/county/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/county/5
        //public void Delete(int id)
        //{
        //}
    }
}