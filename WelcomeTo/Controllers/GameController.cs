﻿using Newtonsoft.Json;
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

            if (Request.IsAjaxRequest())
            {
                return PartialView("_game", gameVM);
            }

            return View(gameVM);
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

            var gamesListVM = GetAvailableGames();

            gamesListVM.Add(new GameListVM { Id = gameVM.Id, Players = new List<string> { name } });

            SaveAvailableGames(gamesListVM);

            return JoinAndWait(gameVM, name);
        }

        public ActionResult Join(string gameId)
        {
            return View((object)gameId);
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

            var gamesListVM = GetAvailableGames();

            var gameListVM = gamesListVM.FirstOrDefault(q => q.Id.Equals(gameId));
            gameListVM.Players.Add(name);

            SaveAvailableGames(gamesListVM);

            return JoinAndWait(gameVM, name);
        }

        public void GameStarted(string gameId)
        {
            var gamesListVM = GetAvailableGames();

            var gameListVM = gamesListVM.FirstOrDefault(q => q.Id.Equals(gameId));
            gamesListVM.Remove(gameListVM);

            SaveAvailableGames(gamesListVM);
        }

        #region Metodi private

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

        private List<GameListVM> GetAvailableGames()
        {
            var dirPath = Server.MapPath(@"~/_db/");

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            var filePath = Server.MapPath(@"~/_db/ActiveGames.json");

            if (!System.IO.File.Exists(filePath))
            {
                return new List<GameListVM>();
            }

            return JsonConvert.DeserializeObject<List<GameListVM>>(System.IO.File.ReadAllText(filePath));
        }

        private void SaveAvailableGames(List<GameListVM> gamesListVM)
        {
            var filePath = Server.MapPath(@"~/_db/ActiveGames.json");

            System.IO.File.WriteAllText(filePath, JsonConvert.SerializeObject(gamesListVM));
        }

        #endregion
    }
}
