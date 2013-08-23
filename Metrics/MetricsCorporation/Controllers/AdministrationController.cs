using System.Web.Mvc;

namespace MetricsCorporation.Controllers
{
    [Authorize(Roles = "master")]
    public class AdministrationController : Controller
    {
        //
        // GET: /Administration/

        public ActionResult Index()
        {
            return View();
        }

    }
}
