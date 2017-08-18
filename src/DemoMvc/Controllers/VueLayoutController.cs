using System.Web.Mvc;

namespace DemoMvc.Controllers
{
    public class VueLayoutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}