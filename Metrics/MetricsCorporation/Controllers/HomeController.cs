using System.Web.Mvc;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Helpers;
using MetricsCorporation.Models;

namespace MetricsCorporation.Controllers
{
    [System.Web.Http.Authorize]
    public class HomeController : Controller
    {
        private readonly ICrud<CompanyModel> _service;

        public HomeController(ICrud<CompanyModel> service)
        {
            _service = service;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Download(string id)
        {
            return File(XmlHelper.GetCompanyModelFile(_service.Get(long.Parse(id))), "text/xml", "data.xml");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DownloadClient(ContactModel model)
        {
            return File(XmlHelper.GetClientModelFile(model), "text/xml", "data.xml");
        }

        public ActionResult Earth(GoogleEarthModel googleEarthModel)
        {
            ViewBag.Url = Helpers.UrlHelper.GetGoogleEarthUrl(googleEarthModel);

            return View();
        }

        [HttpGet]
        public ActionResult LinkedIn(string id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
