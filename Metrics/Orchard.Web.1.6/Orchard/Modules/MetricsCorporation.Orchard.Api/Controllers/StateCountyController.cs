using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;
using MetricsCorporation.BL.Services;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;
using System.Linq;
using System.Text;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class StateCountyController : ApiController
    {
        private readonly ICrud<StateCountyModel> _service;
        private readonly ICrud<UserStatesModel> _serviceUserStates;
        private readonly IHttpContextAccessor _accessor;

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public StateCountyController(IOrchardServices orchardServices, ICrud<StateCountyModel> service, IHttpContextAccessor accessor, ICrud<UserStatesModel> serviceUserStates)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
            _accessor = accessor;
            _serviceUserStates = serviceUserStates;
        }

        [HttpPost]
        public string Get(string id)
        {
            List<StateCountyModel> Response = null;
            if (ModelState.IsValid)
            {
                var session = _accessor.Current().Session;

                if (session != null)
                {
                    UserModel currentUser = null;
                    currentUser = session["CurrentUser"] as UserModel;
                    //List<string> allStates = ((StateCountyService)_service).GetAllStates().ToList();

                    List<string> allowedStates = ((UserStatesService)_serviceUserStates).GetAllStatesByUserId(currentUser.Id).ToList();
                    Response = ((StateCountyService)_service).GetAllByStatePrefix(allowedStates).ToList();
                    var stateGroup = Response.GroupBy(co => co.StateDescription);
                    StringBuilder child = new StringBuilder();
                    StringBuilder parent = new StringBuilder();
                    

                    foreach (var state in stateGroup)
                    {
                        //foreach (string state in allStates)
                        //{
                            //if (grp.Select(co => co.StateDescription).ToList()[0] == state)
                            //{
                                foreach (var county in state)
                                {
                                    child.Append("{ data: '" + county.CountyDescription + "', attr: { id: '" + county.CountyId + "' }},");
                                }

                                parent.Append("{ data: '" + state.Key + "', state:'closed',attr: { id: '" + state.Key + "', code: '" + state.Key + "' }, children : [" + child.Remove(child.Length-1,1) + "]},");
                                child.Clear();
                            //}
                            //else
                            //{
                            //    parent += "{ id:'" + state + "', data: '" + state + "', attr: { rel: 'disabled',id: '" + state + "' }, children : []},";
                            //}
                        //}
                    }

                    return "[" + parent.Remove(parent.Length-1,1) + "]";
                }
            }
            return null;
        }

        // GET api/county
        //public IEnumerable<StateCountyModel> Get()
        //{
        //    return _service.GetAll();
        //}

        // GET api/county/5
        //public string Get(string id)
        //{
        //    return "value";
        //}

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
