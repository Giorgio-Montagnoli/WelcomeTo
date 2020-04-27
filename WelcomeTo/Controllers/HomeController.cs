using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
using WelcomeTo.Models.ViewModels;

namespace WelcomeTo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var filePath = Server.MapPath(@"~/_db/ActiveGames.json");

            if (!System.IO.File.Exists(filePath))
            {
                return View();
            }

            return View(JsonConvert.DeserializeObject<List<GameListVM>>(System.IO.File.ReadAllText(filePath)));
        }
    }
}
