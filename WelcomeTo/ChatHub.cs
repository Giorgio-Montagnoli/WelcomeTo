using Microsoft.AspNet.SignalR;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using WelcomeTo.Models.ViewModels;

namespace WelcomeTo
{
    public class ChatHub : Hub
    {
        public Task Join(string gameId)
        {
            return Groups.Add(Context.ConnectionId, gameId);
        }

        public void HasJoined()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            Clients.Group(gameId).showMessage($"{ name } has joined the game");
        }

        public void SendChat(string msg)
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            Clients.Group(gameId).showMessage($"<span style='color:#337ab7'><b>[ { name } ]</b> says: </span> { msg }");
        }

        public void StartGame()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;
            var gameVM = MemoryCache.Default[gameId] as GameVM;

            if (gameVM.Start())
            {
                Clients.Group(gameId).showMessage($"{ name } started a game at { gameVM.Started.Value }.");
                Clients.Group(gameId).gameStarted(gameId);
            }
        }

        public void NumberPlaced()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            var gameVM = MemoryCache.Default[gameId] as GameVM;
            var player = gameVM.Players.First(q => q.Name.Equals(name));

            gameVM.PlayerHasPlacedNumber(player);

            CanWePlayNextTurn($"{ name } completed his/her turn.", gameVM, gameId);
        }

        public void CantPlace()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            var gameVM = MemoryCache.Default[gameId] as GameVM;
            var player = gameVM.Players.First(q => q.Name.Equals(name));

            gameVM.PlayerCannotPlaceANumber(player);

            CanWePlayNextTurn($"{ name } failed placing number. { name } failures: { player.CannotPlaceANumber }", gameVM, gameId);
        }

        public void ProjectCompleted(int idproject)
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            var gameVM = MemoryCache.Default[gameId] as GameVM;
            var player = gameVM.Players.First(q => q.Name.Equals(name));

            gameVM.PlayerHasCompletedAProject(player, idproject);

            CanWePlayNextTurn($"{ name } has completed project { idproject }", gameVM, gameId);
        }

        private void CanWePlayNextTurn(string message, GameVM gameVM, string gameId)
        {
            Clients.Group(gameId).showMessage(message);

            if (gameVM.CanWePlayNextTurn())
            {
                Clients.Group(gameId).showMessage($"<span style='color: green'>All players completed their turn.</span>");

                if (!gameVM.IsGameEnded())
                {
                    gameVM.Draw();

                    Clients.Group(gameId).showMessage($"<span style='color:red'>*** TURN {gameVM.TurnNo}° ***</span>");
                    Clients.Group(gameId).refreshDrawnCards();
                    Clients.Group(gameId).refreshGameForAll();
                }
                else
                {
                    Clients.Group(gameId).showMessage($"<span style='color:red'>*** GAME ENDED ***</span>");
                }
            }
        }

        public Task Leave(string gameId)
        {
            var name = Clients.Caller.name as string;
            var gameVM = MemoryCache.Default[gameId] as GameVM;

            var player = gameVM.Players.First(q => q.Name.Equals(name));
            gameVM.Players.Remove(player);

            Clients.Group(gameId).showMessage($"{ name } has left the game");

            return Groups.Remove(Context.ConnectionId, gameId);
        }
    }
}