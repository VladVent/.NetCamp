using BlackJack.Logic;
using Microsoft.AspNetCore.SignalR;
namespace SingleBlazorBlackJack.BlackJackHub
{
    public class BlackJackHub : Hub
    {

        private readonly BlackJackMultSessions tableSession;
        public BlackJackHub(BlackJackMultSessions tableSession)
        {
            this.tableSession = tableSession;
        }

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var userName = httpContext.Request.Query["Name"];
            var sessionId = tableSession.GetPlayerAndSession(userName);

            Groups.AddToGroupAsync(Context.ConnectionId, sessionId.ToString());
            Clients.Group(sessionId.ToString()).SendAsync(userName, sessionId);
            return base.OnConnectedAsync();
        }

    }
}
