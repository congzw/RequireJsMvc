using System.Web.Mvc;

namespace DemoMvc.Controllers
{
    public class VueDemoController : Controller
    {
        public ActionResult Tree()
        {
            return View();
        }
        public ActionResult TreePartial()
        {
            return View();
        }

        public ActionResult MenuTree()
        {
            return View();
        }
    }
}