using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WelcomeTo.Helpers;
using WelcomeTo.Models;
using WelcomeTo.Models.ViewModels;

namespace WelcomeTo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Inizializzo il mazzo con tutte le carte
            InitDecks(Utility.AllCards);

            var vm = new GameVM();

            vm.ProjectCards = DrawProjectCards();

            vm.CurrentNumbers = DrawThreeAndfromJsonToDTO();
            Session["currentCards"] = vm.CurrentNumbers;

            vm.CurrentIcons = DrawThreeAndfromJsonToDTO();

            return View(vm);
        }

        public List<ProjectCard> DrawProjectCards()
        {
            var retCars = new List<ProjectCard>();

            var shuffled_1_Cards = Utility.AllProject_1_Cards.OrderBy(q => Guid.NewGuid()).ToList();
            var shuffled_2_Cards = Utility.AllProject_2_Cards.OrderBy(q => Guid.NewGuid()).ToList();
            var shuffled_3_Cards = Utility.AllProject_3_Cards.OrderBy(q => Guid.NewGuid()).ToList();

            retCars.Add(shuffled_1_Cards.First());
            retCars.Add(shuffled_2_Cards.First());
            retCars.Add(shuffled_3_Cards.First());

            return retCars;
        }

        public JsonResult Draw()
        {
            var deck = (List<Card>)Session["Deck"];

            // Pesco le prime tre
            var drawVM = new DrawVM
            {
                Cards = deck.Take(3).ToList()
            };

            // Rimuovo le tre carte pescate
            deck.RemoveRange(0, 3);

            // Se il deck è finito, lo rimescolo, togliendo le ultime tre carte pescate
            if (!deck.Any())
            {
                var remainingCards = Utility.AllCards;

                foreach (var card in drawVM.Cards)
                {
                    var cardToRemove = remainingCards.FirstOrDefault(q => q.IconType.Equals(card.IconType) && q.Number.Equals(card.Number));

                    remainingCards.Remove(cardToRemove);
                }

                InitDecks(remainingCards);
            }

            return new JsonResult { Data = drawVM };
        }

        public List<Card> DrawThreeAndfromJsonToDTO()
        {
            var draw = Draw();
            var tmp = (DrawVM)draw.Data;
            return  tmp.Cards;
        }

        public PartialViewResult DrawAsync() {

            var vm = new GameVM();

            var listOldCards = (List<Card>)Session["currentCards"];
            vm.CurrentIcons = listOldCards;

            vm.CurrentNumbers = DrawThreeAndfromJsonToDTO();
            Session["currentCards"] = vm.CurrentNumbers;

            return PartialView("GameCards", vm);
        }

        public void InitDecks(List<Card> cards)
        {
            // Mescolo le carte e le salvo in sessione
            Session["Deck"] = cards.OrderBy(q => Guid.NewGuid()).ToList();
        }
    }
}