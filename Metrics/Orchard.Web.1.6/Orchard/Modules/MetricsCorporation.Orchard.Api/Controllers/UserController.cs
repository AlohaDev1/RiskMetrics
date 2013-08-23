
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
using Orchard.Mvc;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly ICrud<UserModel> _userService;
        private readonly ICrud<UserStatesModel> _userStatesService;
        public IOrchardServices Services { get; private set; }
        public Localizer T { get; set; }
        private readonly IHttpContextAccessor _accessor;

        public UserController(IOrchardServices orchardServices, ICrud<UserModel> userService, ICrud<UserStatesModel> userStatesService, IHttpContextAccessor accessor)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;
            _userService = userService;
            _userStatesService = userStatesService;

            _accessor = accessor;
        }

        // GET api/user
        [ActionName("Get")]
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return _userService.GetAll();
        }
        
        [AcceptVerbs("GET")]
        [ActionName("Login")]
        [AllowAnonymous]
        public UserModel Login(string userName, string password)
        {
            var session = _accessor.Current().Session;
            var user = ((UserService)_userService).Login(userName, password);
            session["CurrentUser"] = user;

            return user;
        }

        // POST api/filelist
        public UserModel Post(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Create(model);
                if (user != null) ((UserStatesService)_userStatesService).CreateByUserId(model.States, user.Id);
                return user;
            }

            return null;
        }

        // PUT api/user/5
        public HttpResponseMessage Put(int id, UserModel model)
        {
            if (ModelState.IsValid)
            {
                ((UserStatesService)_userStatesService).DeleteByUserId(model.Id);
                ((UserStatesService)_userStatesService).CreateByUserId(model.States, model.Id);
                model.States = "";

                _userService.Update(model);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/user/5
        public HttpResponseMessage Delete(int id)
        {
            if (id == 0)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            _userService.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        
    }

  

}