using System.Web.Mvc;

namespace SmartHive.Web.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration/Administration
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }
    }
}