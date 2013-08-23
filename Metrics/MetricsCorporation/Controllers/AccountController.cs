using System;
using System.Web.Mvc;
using System.Web.Security;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Helpers;
using MetricsCorporation.Models;

namespace MetricsCorporation.Controllers
{
    public class AccountController : Controller
    {

        private readonly ICrud<UserModel> _serviceUserList;
        private readonly ICrud<NumberOfLoginsModel> _serviceNumberOfLogins;

        public AccountController(ICrud<UserModel> serviceUserList, ICrud<NumberOfLoginsModel> serviceNumberOfLogins)
        {
            _serviceUserList = serviceUserList;
            _serviceNumberOfLogins = serviceNumberOfLogins;
        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult LinkedInConnect()
        {
            var obj = new LinkedInConnector(HttpContext, ControllerContext);

            return Redirect(obj.RequestTokenAndAuthorize());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user = ((UserService)_serviceUserList).Login(model.Username, model.Password);

            if (user.Id > 0)
            {
                FormsAuthentication.SetAuthCookie(model.Username, model.Remember);


                SessionHelper.CurrentUser = user;

                //TODO Create master Id model
                Session["company_id"] = 0;// SessionHelper.CurrentUser.CompanyId;

                _serviceNumberOfLogins.Create(new NumberOfLoginsModel
                                                  {
                                                      LoginDate = DateTime.Now,
                                                      UserId = user.Id
                                                  });

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("UserPasswordError", "sorry the username / password you entered was incorrect");

            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            SessionHelper.DropSession(Session);
            FormsAuthentication.SignOut();

            return Redirect("/");
        }

        public ActionResult Confirm()
        {
            var obj = new LinkedInConnector(HttpContext, ControllerContext);
            obj.CallBack();

            var model = obj.GetUserProfile();

            var user = ((UserService)_serviceUserList).GetByName(model.Email);

            if (model.Id == 0)
            {
                user = _serviceUserList.Create(model);
            }

            FormsAuthentication.SetAuthCookie(model.Email, true);


            SessionHelper.CurrentUser = user;

            //TODO Create companyId in the MasterId
            Session["company_id"] = 0;// SessionHelper.CurrentUser.;

            return RedirectToAction("Index", "Home");
        }
    }
}
