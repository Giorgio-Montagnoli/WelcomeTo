using System.Web.Mvc;

namespace WelcomeTo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
