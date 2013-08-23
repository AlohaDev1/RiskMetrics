using System.Web.Mvc;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Themes;

namespace MetricsCorporation.Orchard.Web.Controllers
{
    [Themed]
    [Authorize]
    public class AdministrationController : Controller
    {

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public AdministrationController(IOrchardServices services)
        {
            Services = services;
            T = NullLocalizer.Instance;
        }
       
        //
        // GET: /Administration/

        public ActionResult Index()
        {
            if (!Services.Authorizer.Authorize(Permissions.AdministrationUsers, T("Not allowed this section.")))
                return new HttpUnauthorizedResult();

            return View();
        }
        
    }
}