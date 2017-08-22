using System.Web.Mvc;

namespace DemoMvc.Controllers
{
    public class VueLayout2Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TemplateInline()
        {
            return View();
        }
        public ActionResult TemplateJs()
        {
            return View();
        }
        public ActionResult TemplatePartial()
        {
            return View();
        }
    }
}