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
using Microsoft.AspNetCore.SignalR.Client;
using BlackJack.Domain.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Drawing;

namespace BlackJackBlazor.Pages
{
    public class TableSessionsPage : ComponentBase
    {
        [Parameter]
        public string? Identity { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public Desk desk { get; set; }

        protected override async Task OnInitializedAsync()
        {

            desk = Casino.JoinPlayer(Identity);
            desk.DeskStateUpdated += async (sender, a) => { await InvokeAsync(() => StateHasChanged()); };
            await base.OnInitializedAsync();

        }
        public List<PlayerState> State() => desk.tableSession.players;
        public void TakeCardClick()
        {
            desk.TakeCard(Identity);
        }
        public void StopTakeClick()
        {
            desk.PlayerStop(Identity);
        }

     
    }
}