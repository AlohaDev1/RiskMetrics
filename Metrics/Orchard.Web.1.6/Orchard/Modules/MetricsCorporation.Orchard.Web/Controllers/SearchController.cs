using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;
using MetricsCorporation.Orchard.Web.Helpers;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Themes;
using MetricsCorporation.Data;

namespace MetricsCorporation.Orchard.Web.Controllers
{
    [Themed]
    [Authorize]
    public class SearchController : Controller
    {
        private readonly ICrud<CompanyModel> _companyService;
        private readonly ICrud<ExportedModel> _exportService;
        private readonly IHttpContextAccessor _accessor;
        private readonly ICrud<CompanyAutocompleteModel> _Companyautocompleteservice;

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public SearchController(ICrud<CompanyModel> companyService, IOrchardServices services, ICrud<ExportedModel> exportService, IHttpContextAccessor accessor, ICrud<CompanyAutocompleteModel> CompanyautocompleteService)
        {
            _companyService = companyService;
            _exportService = exportService;
            _accessor = accessor;
            _Companyautocompleteservice = CompanyautocompleteService;
            Services = services;
            T = NullLocalizer.Instance;

        }

        public ActionResult Index()
        {
            if (!Services.Authorizer.Authorize(Permissions.SearchSection, T("Not allowed this section.")))
                return new HttpUnauthorizedResult();

            return View();
        }

        [HttpGet]
        public ActionResult Download(string id)
        {
            return File(XmlHelper.GetCompanyModelFile(_companyService.Get(long.Parse(id))), "text/xml", "data.xml");
        }

        [HttpPost]
        [Themed(false)]
        public ActionResult ExportCompanies(ExportModel model)
        {
            if (model.CompanyIds.Count > 0 && !string.IsNullOrEmpty(model.ExportFileName))
            {
                var companies = ((CompanyModelService)_companyService).GetByIds(model.CompanyIds);
                FileContentResult file;
                if (model.ExportType.Equals("xml"))
                    file = File(XmlHelper.GetCompanyModelFile(companies.First()), "text/xml", string.Format("{0}_{1}.xml", model.ExportFileName, DateTime.Now.ToString("yyyyMMdd")));
                else
                {
                    var csv = new CsvExport<CompanyModel>(companies.ToList());
                    file = File(csv.ExportToBytes(), "text/csv", string.Format("{0}_{1}.csv", model.ExportFileName, DateTime.Now.ToString("yyyyMMdd")));
                }


                return file;
            }

            return null;
        }

        [HttpPost]
        [Themed(false)]
        public ActionResult SaveExportCompanies(ExportModel2 model)
        {
            if (model.CompanyIds.Length > 0 && !string.IsNullOrEmpty(model.ExportFileName))
            {
                var session = _accessor.Current().Session;
                if (session != null)
                {
                    var currentUser = session["CurrentUser"] as UserModel;

                    if (currentUser != null)
                    {
                        var exportCount = model.CompanyIds.Length;
                        var alreadyExported = _exportService.GetAllById(currentUser.Id);
                        exportCount = exportCount + alreadyExported.Sum(a => a.RecordsExportedCount);

                        if (exportCount < currentUser.MaxExports && currentUser.CanexportList)
                        {
                            var ids = new List<long>();
                            ids.AddRange(model.CompanyIds.Select(long.Parse));

                            _exportService.Create(new ExportedModel()
                            {
                                FileName = string.Format("{0}_{1}", model.ExportFileName, DateTime.Now.ToString("yyyyMMdd")),
                                UserId = currentUser.Id,
                                ExportedOn = DateTime.UtcNow,
                                RecordsExportedCount = model.CompanyIds.Length,
                                CompanyIds = ids
                            });

                            return Json(true, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new ExportResponse()
                            {
                                CanExport = currentUser.CanexportList,
                                CurrentRequest = model.CompanyIds.Length,
                                TotalPerMonthAvailable = currentUser.MaxExports,
                                TotalPerMonthExported = alreadyExported.Sum(a => a.RecordsExportedCount),
                            }, JsonRequestBehavior.AllowGet);
                        }

                    }
                }
            }

            return null;
        }


        [HttpGet]
        public ActionResult DownloadClient(ContactModel model)
        {
            return File(XmlHelper.GetClientModelFile(model), "text/xml", "data.xml");
        }

        [Themed(false)]
        public ActionResult Earth(GoogleEarthModel googleEarthModel)
        {
            ViewBag.Url = Helpers.UrlHelper.GetGoogleEarthUrl(googleEarthModel);

            return View();
        }

        [HttpGet]
        [Themed(false)]
        public ActionResult LinkedIn(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        //[HttpGet]
        //[Themed(false)]
        //public PartialViewResult SicCodeTree()
        //{
        //    return PartialView("_SicCodeTree");
        //}

       


    }

    public class ExportModel
    {
        public List<string> CompanyIds { get; set; }
        public string ExportType { get; set; }
        public string ExportFileName { get; set; }
    }

    public class ExportModel2
    {
        public string[] CompanyIds { get; set; }
        public string ExportType { get; set; }
        public string ExportFileName { get; set; }
    }

    public class ExportResponse
    {
        public bool CanExport { get; set; }
        public int TotalPerMonthExported { get; set; }
        public int TotalPerMonthAvailable { get; set; }
        public int CurrentRequest { get; set; }

    }
}


