using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using BlackJackBlazor;
using BlackJack.Logic;
using BlackJackWeb;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using BlackJackBlazorServer.Models;
using BlackJack.BLL.Services;
using BlackJackBlazorServer.Hubs;

namespace BlackJackBlazor.Pages
{
    public class TableSessionsPage : ComponentBase
    {
        [Parameter]
        public string Identity { get; set; }
        [Inject]
        private ISessionService sessionService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        private IHubContext<BlackJackHub> HubContext { get; set; }

        public string ErrorMessage { get; set; }
        public int SessionId { get; set; }
        public TableSession Session { get; set; }

        private HubConnection connection;

        protected override async Task OnInitializedAsync()
        {
            if (connection == null)
            {
                connection = new HubConnectionBuilder()
                       .WithUrl(NavigationManager.ToAbsoluteUri($"/blackjackhub?username={Identity}"))
                       .Build();

                await connection.StartAsync();

                connection.Closed += async (error) =>
                {
                    ErrorMessage = "Game Over";
                    StateHasChanged();
                };
                connection.On<int>(SignalMethods.Session.SessionRecieve, (session) =>
                {
                    try
                    {
                        SessionId = session;
                        Session = sessionService.GetSessionById(SessionId);
                        StateHasChanged();
                    }
                    catch { }
                });
            }

            await base.OnInitializedAsync();

        }

        public void Back()
        {
            NavigationManager.NavigateTo("/");
            connection.StopAsync();
        }

        public void TakeCardClick()
        {
            sessionService.PlayerTakeCard(Session, Identity);
            HubContext.Clients.Group(SessionId.ToString()).SendAsync(SignalMethods.Session.SessionRecieve, SessionId);
        }

        public void StopClick()
        {
            sessionService.PlayerWouldStop(Session, Identity);
            HubContext.Clients.Group(SessionId.ToString()).SendAsync(SignalMethods.Session.SessionRecieve, SessionId);
        }
        #region no need
        public TableSession tableSession { get; set; }

        public string TakeStats = string.Empty;
        public string TakeSumScore()
        {
            foreach (var p in tableSession.players)
            {
                TakeStats = p.SumPoint.ToString();
            }
            return TakeStats;
        }
        public string TakePlayerName()
        {
            foreach (var p in tableSession.GetState().Players)
            {
                TakeStats = p.playerName;
            }
            return TakeStats;
        }
        public string TakePlayerState()
        {
            foreach (var p in tableSession.GetState().Players)
            {
                TakeStats = p.state.ToString();
            }
            return TakeStats;
        }

        public string TakeCardCount()
        {
            foreach (var p in tableSession.GetState().Players)
            {
                TakeStats = p.cardCount.ToString();
            }
            return TakeStats;
        }
        public void PlayerTakeCard()
        {
            var player = tableSession.players;
            foreach (var p in player)
            {
                tableSession.PlayerTakeCard(p);
            }
            TakeSumScore();
            TakeCardCount();
        }

        public void PlayerWouldLikeStop()
        {
            var player = tableSession.players;
            foreach (var p in player)
            {
                tableSession.PlayerWouldLikeStop(p);
            }
            TakeSumScore();
            TakeCardCount();
            TakePlayerState();
        }
        #endregion
    }
}