
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;

using Orchard;
using Orchard.Localization;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class RoleController : ApiController
    {
        private readonly ICrud<UserModel> _userService;
        private readonly ICrud<UserStatesModel> _userStatesService;
        public IOrchardServices Services { get; private set; }
        public Localizer T { get; set; }

        public RoleController(IOrchardServices orchardServices, ICrud<UserModel> userService, ICrud<UserStatesModel> userStatesService)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;
            _userService = userService;
            _userStatesService = userStatesService;
        }

        // GET api/user
      
        public IEnumerable<Role> Get()
        {
            return ((UserService)_userService).GetRoles();
        }
        
    }

  

}