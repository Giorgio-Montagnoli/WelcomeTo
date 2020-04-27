using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

            return View(gameVM);
        }

        public PartialViewResult Game()
        {
            var cookieGameId = Request.Cookies.Get(Utility.COOKIE_GAME_ID);

            var gameVM = MemoryCache.Default[cookieGameId.Value] as GameVM;

            return PartialView(gameVM);
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

            //AddGameIdToJsonFile(gameVM.Id);

            return JoinAndWait(gameVM, name);
        }

        public ActionResult Join()
        {
            //var vm = GetAvailableGames();
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

        private List<string> GetAvailableGames()
        {
            var filePath = Server.MapPath(@"~/ActiveGames.json");
            //JArray jsonFileRead = JArray.Parse(System.IO.File.ReadAllText(filePath));

            var jsonFileRead = System.IO.File.ReadAllText(System.IO.File.ReadAllText(filePath));
            var games = JsonConvert.DeserializeObject<List<string>>(jsonFileRead);

            return games;
        }

        public void AddGameIdToJsonFile(string gameId)
        {
            var filePath = Server.MapPath(@"~/ActiveGames.json");
            JArray jsonFileRead = JArray.Parse(System.IO.File.ReadAllText(filePath));

            JObject obj = new JObject();
            obj.Add("id", gameId);

            jsonFileRead.Add(obj);

            System.IO.File.WriteAllText(filePath, jsonFileRead.ToString());

            // write JSON directly to a file
            using (StreamWriter file = System.IO.File.CreateText(filePath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                jsonFileRead.WriteTo(writer);
            }
        }

        public void RemoveGameIdFromJsonFile(string gameId)
        {
            var filePath = Server.MapPath(@"~/ActiveGames.json");
            JArray jsonFileRead = JArray.Parse(System.IO.File.ReadAllText(filePath));

            foreach (JObject elem in jsonFileRead)
            {
                foreach (var elementToRemove in new List<string>() { gameId })
                {
                    elem.Property(elementToRemove).Remove();
                }
            }
        }
    }
}
