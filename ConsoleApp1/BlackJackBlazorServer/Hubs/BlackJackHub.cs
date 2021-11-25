using BlackJack.BLL.Services;
using BlackJackBlazorServer.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlackJackBlazorServer.Hubs
{
    public class BlackJackHub : Hub
    {
        private readonly ISessionService sessionService;
        public BlackJackHub(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public void SendSessionUpdated(int sessionId)
        {
            Clients.Groups(sessionId.ToString()).SendAsync(SignalMethods.Session.SessionRecieve, sessionId);
        }

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var userName = httpContext.Request.Query["username"];

            try
            {
                var sessionId = sessionService.FindSession(Context.ConnectionId, userName);

                Groups.AddToGroupAsync(Context.ConnectionId, sessionId.ToString());
                Clients.Groups(sessionId.ToString()).SendAsync(SignalMethods.Session.SessionRecieve, sessionId);

                Clients.Caller.SendAsync(SignalMethods.Session.SuccessfullyConnected, sessionId);
            }
            catch { }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            try
            {
                var sessionId = sessionService.RemoveUserFromSession(Context.ConnectionId);

                Clients.Groups(sessionId.ToString()).SendAsync(SignalMethods.Session.SessionRecieve, sessionId);
            }
            catch { }


            return base.OnDisconnectedAsync(exception);
        }
    }
}
