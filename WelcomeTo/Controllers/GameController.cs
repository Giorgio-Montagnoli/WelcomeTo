using System;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using WelcomeTo.Helpers;
using WelcomeTo.Models;
using WelcomeTo.Models.ViewModels;

namespace WelcomeTo.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            var cookieGameId = Request.Cookies.Get(Utility.COOKIE_GAME_ID);

            if (cookieGameId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var gameVM = MemoryCache.Default[cookieGameId.Value] as GameVM;

            if (gameVM == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult StartANewGame()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StartANewGame(string name)
        {
            var gameVM = new GameVM();

            MemoryCache.Default.Add(gameVM.Id, gameVM, new CacheItemPolicy());

            return JoinAndWait(gameVM, name);
        }

        public ActionResult Join()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Join(string name, string gameId)
        {
            var gameVM = MemoryCache.Default[gameId] as GameVM;

            if (gameVM == null)
            {
                return RedirectToAction("GameNotFound");
            }
            else if (gameVM.Started.HasValue)
            {
                return RedirectToAction("GameStarted");
            }
            else if (gameVM.Players.Any(q => q.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                return RedirectToAction("UsernameAlreadyUsed");
            }

            return JoinAndWait(gameVM, name);
        }

        private ActionResult JoinAndWait(GameVM gameVM, string name)
        {
            gameVM.Players.Add(new Player { Name = name });

            Response.Cookies.Add(
                new HttpCookie(Utility.COOKIE_GAME_ID)
                {
                    Value = gameVM.Id,
                    Expires = DateTime.Now.AddDays(1)
                });

            Response.Cookies.Add(
                new HttpCookie(Utility.COOKIE_GAME_NAME)
                {
                    Value = name,
                    Expires = DateTime.Now.AddDays(1)
                });

            return RedirectToAction("Index");
        }
    }
}
