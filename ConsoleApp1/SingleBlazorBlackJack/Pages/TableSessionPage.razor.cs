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
using SingleBlazorBlackJack;
using Microsoft.AspNetCore.SignalR;
using SingleBlazorBlackJack.BlackJackHub;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlackJackBlazor.Pages
{
    public class TableSessionsPage : ComponentBase
    {
        [Parameter]
        public string? Identity { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public BlackJackMultSessions? BlackJack { get; set; }

        //protected override async Task OnInitializedAsync()
        //{
        //    if (connection == null)
        //    {
        //        connection = new HubConnectionBuilder()
        //               .WithUrl(NavigationManager.ToAbsoluteUri($"/blackjackhub?Name={Identity}"))
        //               .Build();

        //        await connection.StartAsync();

        //        connection.On<string>(Identity, (session) =>
        //        {
        //            _ = BlackJack.tableSession;
        //                StateHasChanged();
        //        });
        //    }

        //    await base.OnInitializedAsync();

        //}
        public List<PlayerState> State() => BlackJack.tableSession.players;
        public void TakeCardClick()
        {
            BlackJack.TakeCard(Identity);
        }
        public void StopTakeClick()
        {
            BlackJack.PlayerStop(Identity);
        }

        public void RestartRoundClick()
        {
            BlackJack.RestartRound();
        }
    }
}