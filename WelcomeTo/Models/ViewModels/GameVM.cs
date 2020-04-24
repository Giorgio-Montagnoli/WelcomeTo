using System;
using System.Collections.Generic;
using System.Linq;
using WelcomeTo.Helpers;

namespace WelcomeTo.Models.ViewModels
{
    public class GameVM
    {
        internal string _id;
        public string Id
        {
            get
            {
                return _id;
            }
        }

        public List<Player> Players { get; set; }
        public List<Card> Cards { get; set; }
        public List<Card> CurrentIcons { get; set; }
        public List<Card> CurrentNumbers { get; set; }
        public List<ProjectCard> SelectedProjects { get; set; }
        public int TurnNo { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Ended { get; set; }

        public GameVM(List<Player> players)
        {
            // Creo la sesssione di gioco
            _id = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            // Aggiungo i giocatori
            Players = players;

            // Faccio un mazzo con tutte le carte
            Cards = Utility.AllCards;
            ShuffleCards();

            // Tre progetti a caso
            SelectedProjects = new List<ProjectCard>
            {
                Utility.AllProject_1_Cards.OrderBy(q => Guid.NewGuid()).First(),
                Utility.AllProject_2_Cards.OrderBy(q => Guid.NewGuid()).First(),
                Utility.AllProject_3_Cards.OrderBy(q => Guid.NewGuid()).First()
            };

            // Pesco le prime tre e le giro per le icone
            CurrentIcons = Cards.Take(3).ToList();
            // Pesco le successive tre carte per i numeri
            CurrentNumbers = Cards.Skip(3).Take(3).ToList();

            // Rimuovo le sei carte pescate
            Cards.RemoveRange(0, 3);

            TurnNo = 1;
        }

        public void Draw()
        {
            // Giro le tre carte numero sul lato icone
            CurrentIcons = CurrentNumbers;
            // Pesco le prime tre carte
            CurrentNumbers = Cards.Take(3).ToList();
            // Rimuovo le tre carte pescate
            Cards.RemoveRange(0, 3);

            // Se il deck è finito, lo rimescolo, togliendo le ultime tre carte pescate
            if (!Cards.Any())
            {
                Cards = Utility.AllCards;

                foreach (var card in CurrentNumbers)
                {
                    var cardToRemove = Cards.FirstOrDefault(q => q.IconType.Equals(card.IconType) && q.Number.Equals(card.Number));

                    Cards.Remove(cardToRemove);
                }

                ShuffleCards();
            }

            TurnNo++;
        }

        public void PlayerHasPlacedNumber(Player player)
        {
            player.TurnDone = true;
        }

        public void PlayerCannotPlaceANumber(Player player)
        {
            player.CannotPlaceANumber++;
            player.TurnDone = true;
        }

        public void PlayerHasPlacedAllNumbers(Player player)
        {
            player.HasPlacedAllNumbers = true;
            player.TurnDone = true;
        }

        public void PlayerHasCompletedAProject(Player player, int projectNo)
        {
            // La posizione è sempre il numero - 1
            var projectToChange = SelectedProjects.ElementAt(projectNo - 1);

            projectToChange.Approved = true;

            player.CompletedProjects++;
            player.TurnDone = true;
        }

        public bool CanWePlayNextTurn()
        {
            return Players.All(q => q.TurnDone);
        }

        public bool IsGameEnded()
        {
            if (Players.Any(q => q.HasPlacedAllNumbers) ||
                Players.Any(q => q.CannotPlaceANumber > 2) ||
                Players.Any(q => q.CompletedProjects > 2))
            {
                Ended = DateTime.Now;
                return true;
            }

            return false;
        }


        void ShuffleCards()
        {
            // Mescolo le carte un paio di volte
            for (var i = 0; i < 3; i++)
            {
                Cards = Cards.OrderBy(q => Guid.NewGuid()).ToList();
            }
        }
    }
}