using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;
using MetricsCorporation.Orchard.Api.Controllers;
using MetricsCorporation.Orchard.Web.Helpers;
using MetricsCorporation.Orchard.Web.Models;
using Orchard;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.Themes;
using RestSharp;
 

namespace MetricsCorporation.Orchard.Web.Controllers
{
    [Themed]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ICrud<ExportedModel> _exportedService;
        private readonly ICrud<CompanyModel> _companyService;
        private readonly ICrud<UsageInfoModel> _serviceUsageInfo;
        private readonly ICrud<UserModel> _userService;
        private readonly ICrud<NumberOfLoginsModel> _numberOfLoginsService;
        private readonly ICrud<SearchLogModel> _searchLogService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMembershipService _membershipService;
        private readonly IMapper _mapper;

        public AccountController(IHttpContextAccessor accessor, 
                                ICrud<ExportedModel> exportedService, ICrud<CompanyModel> companyService, ICrud<UsageInfoModel> serviceUsageInfo,
                                ICrud<UserModel> userService,
                                ICrud<NumberOfLoginsModel> numberOfLoginsService,
                                ICrud<SearchLogModel> searchLogService,
                                IAuthenticationService authenticationService,
                                IMembershipService membershipService,
                                IMapper mapper)
        {
            _accessor = accessor;
            _exportedService = exportedService;
            _companyService = companyService;
            _serviceUsageInfo = serviceUsageInfo;
            _userService = userService;
            _numberOfLoginsService = numberOfLoginsService;
            _searchLogService = searchLogService;
            _authenticationService = authenticationService;
            _membershipService = membershipService;
            _mapper = mapper;
        }


        [AllowAnonymous]
        public ActionResult LinkedInConnect()
        {
           // SocialAuthUser.GetCurrentUser().Login(PROVIDER_TYPE.LINKEDIN);

            var obj = new LinkedInConnector(HttpContext, ControllerContext);

            return Redirect(obj.RequestTokenAndAuthorize("Confirm"));
        }

        [AllowAnonymous]
        public ActionResult AddLinkedInAccount()
        {
            var obj = new LinkedInConnector(HttpContext, ControllerContext);

            return Redirect(obj.RequestTokenAndAuthorize("AddAccount"));
        }
        /// <summary>
        /// Remove linkedin account relation from the user account
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult RemoveLinkedAccount()
        {           
            var session = _accessor.Current().Session;
            if (session != null)
            {
                var currentUser = session["CurrentUser"] as UserModel;
                if (currentUser != null)
                {
                    var user = ((UserService)_userService).UpdateUserWithLinkedId(currentUser.Id, "");

                    session["CurrentUser"] = user;
                }
            }

          return RedirectToAction("Index");
        }

        //[AllowAnonymous]
        public ActionResult AddAccount()
        {
            var obj = new LinkedInConnector(HttpContext, ControllerContext);
            obj.CallBack();

            var model = obj.GetUserProfile();
            var session = _accessor.Current().Session;
            if (session != null)
            {
                var currentUser = session["CurrentUser"] as UserModel;
                if (currentUser != null)
                {
                    var user = ((UserService)_userService).UpdateUserWithLinkedId(currentUser.Id, model.LinkedInId);
                    
                    session["CurrentUser"] = user;
                }
            }


            //if (string.IsNullOrEmpty(model.UserName))
            //    //model.UserName = string.Concat(model.FirstName, model.LastName);
            //    model.UserName = string.Concat(model.FirstName, model.LastName);

            //var user = ((UserService)_userService).GetByLinkedInId(model.UserName);



            //prevent login with empty passowrd
            //model.Password = GenerateRandomPassword();

            //if ((user == null) || (user != null && user.Id == 0))
            //{

            //    if (string.IsNullOrEmpty(model.CompanyName)) model.CompanyName = string.Empty;

            //    user = _userService.Create(model);
            //    if (user.Id > 0)
            //    {
            //        //FormsAuthentication.SetAuthCookie(model.UserName, true);

            //        var iUser = _membershipService.ValidateUser(model.UserName, model.Password);
            //        _authenticationService.SignIn(iUser, true);
            //    }
            //}
            //else
            //{
            //    var iUser = _membershipService.ValidateUser(user.UserName, user.Password);
            //    _authenticationService.SignIn(iUser, true);
            //}

            //TODO Create companyId in the MasterId
            //Session["company_id"] = 0;// SessionHelper.CurrentUser.;

           // return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Account");
            
        }
        
        [AllowAnonymous]
        public ActionResult Confirm()
        {
            var obj = new LinkedInConnector(HttpContext, ControllerContext);
            obj.CallBack();

            var model = obj.GetUserProfile();

            //var user = ((UserService)_userService).GetByLinkedInId(model.UserName);
            var user = ((UserService)_userService).GetByLinkedInId(model.LinkedInId);

            //prevent login with empty passowrd
            model.Password = GenerateRandomPassword();

            if ((user == null) || (user != null && user.Id == 0))
            {
                
                if (string.IsNullOrEmpty(model.CompanyName)) model.CompanyName = string.Empty;
                if (user == null)
                {
                    model.ActivationDate = DateTime.Now;
                    model.UserName = string.IsNullOrEmpty(model.FirstName) ? "" : model.FirstName; 
                    model.CompanyName = "";
                    model.MaxJigsawExports = 0;
                    model.MaxJigsawReportsViewsPerMonth = model.MaxJigsawReportsViewsPerYear = model.MaxReportViewsPerMonth = model.MaxReportViewsPerYear = model.MaxExports = 0;
                    model.TestAccount = model.ShowCarrier = model.ShowStatusFld = model.InternalAccount = false;
                }
                user = _userService.Create(model);
                if (user.Id > 0)
                {
                    //FormsAuthentication.SetAuthCookie(model.UserName, true);

                    var iUser = _membershipService.ValidateUser(model.Email, model.Password);
                    _authenticationService.SignIn(iUser, true);
                }
            }else
            {
                var iUser = _membershipService.ValidateUser(user.Email, user.Password);
                _authenticationService.SignIn(iUser, true);
            }

            //TODO Create companyId in the MasterId
            //Session["company_id"] = 0;// SessionHelper.CurrentUser.;

            return RedirectToAction("Index", "Account");
           // return Redirect("../Account/Index");
        }

        public string GenerateRandomPassword()
        {
            var allowedChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var data = new byte[10];
            var crypt = new RNGCryptoServiceProvider();

            crypt.GetNonZeroBytes(data);
            var result = new StringBuilder();
            foreach (var b in data)
                result.Append(allowedChars[b % (allowedChars.Length - 1)]);

            return result.ToString();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUserSettings()
        {
            var session = _accessor.Current().Session;
            if (session != null)
            {
                var currentUser = session["CurrentUser"] as UserModel;
                if (currentUser != null)
                {
                    var userSettings = new UserSettingsModel()
                                           {
                                               ShowRenewalMonth = !currentUser.TestAccount,
                                               ShowMoreThan1Page= !currentUser.TestAccount
                                           };

                    return Json(JsonHelper.Serialize(userSettings), JsonRequestBehavior.AllowGet);    
                }
            }

            return null;
        }


        public ActionResult DownloadReport(int reportId, string type)
        {
            var model = _exportedService.Get(reportId);

            // prevent different user get report 
            var session = _accessor.Current().Session;
            if (session != null)
            {
                var currentUser = session["CurrentUser"] as UserModel;
                if (currentUser != null)
                {
                    if (currentUser.Id != model.UserId) return null;
                }
            }

            if (model.CompanyIds.Count > 0 && !string.IsNullOrEmpty(model.FileName))
            {
                var ids = new List<string>();
                ids.AddRange(model.CompanyIds.Select(i => i.ToString(CultureInfo.InvariantCulture)));
                var companies = ((CompanyModelService)_companyService).GetByIds(ids);

                FileContentResult file;
                if (type.Equals("xml"))
                    file = File(XmlHelper.GetCompanyModelFile(companies.First()), "text/xml", string.Format("{0}.xml", model.FileName));
                else
                {
                    var csv = new CsvExport<CompanyModel>(companies.ToList());
                    file = File(csv.ExportToBytes(), "text/csv", string.Format("{0}.csv", model.FileName));
                }


                return file;
            }

            return null;
        }

        public ActionResult SubcribtionDetails()
        {
            var session = _accessor.Current().Session;
            if (session != null)
            {
                var currentUser = session["CurrentUser"] as UserModel;
                if (currentUser != null)
                {
                    //var subscribtion = new SubscribtionModel()
                    //{
                    //    Id = currentUser.Id,
                    //    UserName = currentUser.UserName,
                    //    ActivationDate = currentUser.ActivationDate,
                    //    CanexportList = currentUser.CanexportList,
                    //    CompanyName = currentUser.CompanyName,
                    //    ExpirationDate = currentUser.ExpirationDate,
                    //    MaxExports = currentUser.MaxExports,
                    //    MaxJigsawExports = currentUser.MaxJigsawExports,
                    //    MaxJigsawReportsViewsPerMonth = currentUser.MaxJigsawReportsViewsPerMonth,
                    //    MaxReportViewsPerMonth = currentUser.MaxReportViewsPerMonth,
                    //    //UserName = string.Format("{0} {1}", currentUser.LastName, currentUser.FirstName),
                    //    Email = currentUser.Email,
                    //    RenewalDate = currentUser.RenewalDate,
                    //    States = currentUser.States,
                    //    LinkedInId = currentUser.LinkedInId
                    //};
                    var subscribtion = _mapper.Map<UserModel, SubscribtionModel>(currentUser);
                    subscribtion.RecordsExported = _exportedService.GetAllById(subscribtion.Id).Sum(i => i.RecordsExportedCount);

                    //Aloha [TO-DO] need unique indentifier in the usageinfo table to identify the number of reports viewed by the customer
                    //subscribtion.ReportsViewed = ((UsageInfoService)_serviceUsageInfo).GetAllById(currentUser.Id).Count();
                    subscribtion.ReportsViewed = ((UsageInfoService)_serviceUsageInfo).GetAllByEmail(currentUser.Email);

                    return Json(JsonHelper.Serialize(subscribtion), JsonRequestBehavior.AllowGet);
                }
            }

            return null;
        }

        public ActionResult GetAllUsers()
        {
            var session = _accessor.Current().Session;
            if (session != null)
            {
                var currentUser = session["CurrentUser"] as UserModel;
                if (currentUser != null)
                {
                    if (currentUser.Admin)
                    {

                        var users = ((UserService)_userService).GetByCompanyName(currentUser.CompanyName);
                        //var userModels = new List<UserModel>();

                        foreach (var user in users)
                        {

                            var numberOfLogins = _numberOfLoginsService.GetAllById(user.Id);
                            if (numberOfLogins != null)
                            {
                                user.LoginCount = numberOfLogins.Sum(u => u.Count);
                                user.TotalReportsViewed = ((UsageInfoService)_serviceUsageInfo).GetAllById(user.Id).Count();
                                user.TotalReportsExported = _exportedService.GetAllById(user.Id).Sum(i => i.RecordsExportedCount);

                                var numberOfLoginsModel = numberOfLogins.OrderByDescending(d => d.LoginDate).FirstOrDefault();
                                if (numberOfLoginsModel != null)
                                    user.LastLoginDate = numberOfLoginsModel.LoginDate;

                            }

                            //userModels.Add(model);
                        }

                        return Json(JsonHelper.Serialize(users), JsonRequestBehavior.AllowGet);
                    }
                }
            }

            return null;
        }


    }
}
