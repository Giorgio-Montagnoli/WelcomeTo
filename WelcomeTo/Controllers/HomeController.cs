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

            return View();
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

        public void InitDecks(List<Card> cards)
        {
            // Mescolo le carte e le salvo in sessione
            Session["Decks"] = cards.OrderBy(q => Guid.NewGuid()).ToList();
        }
    }
}