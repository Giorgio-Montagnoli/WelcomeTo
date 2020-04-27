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

        public Task Leave(string gameId)
        {
            var name = Clients.Caller.name as string;
            var gameVM = MemoryCache.Default[gameId] as GameVM;

            var player = gameVM.Players.First(q => q.Name.Equals(name));
            gameVM.Players.Remove(player);

            Clients.Group(gameId).showMessage($"{ name } ha lasciato la partita");

            return Groups.Remove(Context.ConnectionId, gameId);
        }

        public void HasJoined()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            Clients.Group(gameId).showMessage($"{ name } è entrato/a in partita");
        }

        public void NumberPlaced()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            var gameVM = MemoryCache.Default[gameId] as GameVM;
            var player = gameVM.Players.First(q => q.Name.Equals(name));

            gameVM.PlayerHasPlacedNumber(player);

            Clients.Group(gameId).showMessage($"{ name } ha completato la sua mossa");
            Clients.Caller.hasDone();

            if (gameVM.CanWePlayNextTurn())
            {
                Clients.Group(gameId).showMessage($"<span style='color: green'>Tutti i giocatori hanno completato la propria mossa</span>");
            }
        }

        public void CantPlace()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            var gameVM = MemoryCache.Default[gameId] as GameVM;
            var player = gameVM.Players.First(q => q.Name.Equals(name));

            gameVM.PlayerCannotPlaceANumber(player);

            Clients.Group(gameId).showMessage($"{ name } ha fallito nel piazzare un numero. Numero di fallimenti di {name}: {player.CannotPlaceANumber}");
            Clients.Caller.cantPlaceNumber();

            if (gameVM.CanWePlayNextTurn())
            {
                Clients.Group(gameId).showMessage($"<span style='color: green'>Tutti i giocatori hanno completato la propria mossa</span>");
            }
        }

        public void ProjectCompleted(int idproject)
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            var gameVM = MemoryCache.Default[gameId] as GameVM;
            var player = gameVM.Players.First(q => q.Name.Equals(name));

            gameVM.PlayerHasCompletedAProject(player, idproject);

            Clients.Group(gameId).showMessage($"{ name } ha completato il progetto {idproject}");
            Clients.Caller.projectHasBeenCompleted(idproject);
            Clients.Group(gameId).refreshGameForAll();
        }

        public void DrawNewCards()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;
            var gameVM = MemoryCache.Default[gameId] as GameVM;

            gameVM.Draw();

            Clients.Group(gameId).showMessage($"<span style='color:red'>*** { name } ha pescato tre nuove carte. TURNO {gameVM.TurnNo}° ***</span>");
            Clients.Group(gameId).refreshDrawnCards();
            Clients.Group(gameId).refreshGameForAll();
        }

        public void StartGame()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;
            var gameVM = MemoryCache.Default[gameId] as GameVM;

            gameVM.Start();

            Clients.Group(gameId).showMessage($"{ name } ha avviato la partita alle { gameVM.Started.Value }.");
            Clients.Group(gameId).gameStarted(gameId);
            Clients.Group(gameId).refreshGameForAll();
        }

        public void SendChat(string msg)
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            Clients.Group(gameId).showMessage($"<span style='color:#337ab7'><b>[ { name } ]</b> says: </span> { msg }");
        }
    }
}