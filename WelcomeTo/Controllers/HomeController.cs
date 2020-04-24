using System.Web.Mvc;
using WelcomeTo.Models.ViewModels;

namespace WelcomeTo.Controllers
{
    public class HomeController : Controller
    {
        private GameVM GetGameVM(string id)
        {
            return (GameVM)Session[id];
        }

        private void SaveGameVM(GameVM gameVM)
        {
            Session[gameVM.Id] = gameVM;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
