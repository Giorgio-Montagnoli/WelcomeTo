using Microsoft.AspNet.SignalR;
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
            return Groups.Remove(Context.ConnectionId, gameId);
        }

        public void hasJoined()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;

            Clients.Group(gameId).consoleLog($"{ name } è entrato/a in partita");
        }

        public void StartGame()
        {
            var gameId = Clients.Caller.gameId as string;
            var name = Clients.Caller.name as string;
            var gameVM = MemoryCache.Default[gameId] as GameVM;

            gameVM.Start();

            Clients.Group(gameId).consoleLog($"{ name } ha avviato la partita alle { gameVM.Started.Value }");
            Clients.Group(gameId).gameStarted(gameId);
        }
    }
}