using System.Web.Mvc;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;
using Orchard;
using Orchard.Localization;
using Orchard.Themes;

namespace MetricsCorporation.Orchard.Web.Controllers
{
    [Themed]
    [Authorize]
    public class LogReportsController : Controller
    {
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public LogReportsController(IOrchardServices services)
        {
            Services = services;
            T = NullLocalizer.Instance;
            
        }
        
        //
        // GET: /LogReports/

        public ActionResult Index()
        {
            if (!Services.Authorizer.Authorize(Permissions.LogReports, T("Not allowed this section.")))
                return new HttpUnauthorizedResult();

            return View();
        }

    }
}