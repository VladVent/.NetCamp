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
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using BlackJackBlazor;
using BlackJackBlazor.Shared;
using BlackJack.Logic;
using Microsoft.AspNetCore.Http.Extensions;
using BlackJackWeb;

namespace BlackJackBlazor.Pages
{
    public partial class IndexModel : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public BlackJackWebSessions blackJackSessions = new BlackJackWebSessions();
        public string identity = string.Empty;
      
        public void Navigator(string identity)
        {
            identity = this.identity;
            blackJackSessions.AddPlayersInSessions(identity);
            NavigationManager.NavigateTo("TableSessionPage");
        }
    }
}