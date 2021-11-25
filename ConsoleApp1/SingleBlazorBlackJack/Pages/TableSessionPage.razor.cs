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


namespace BlackJackBlazor.Pages
{
    public class TableSessionsPage : ComponentBase
    {
        [Parameter]
        public string? Identity { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public String RouteName = "";

        public BlackJackMultSessions? BlackJack { get; set; }

        public BlackJackMultSessions GetPlayers()
        {
            BlackJack.GetPlayerAndSession(Identity);
            return BlackJack;
        }
    }
}