using System.Web.Mvc;

namespace DemoMvc.Controllers
{
    public class VuePageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Space()
        {
            return View();
        }
    }
}