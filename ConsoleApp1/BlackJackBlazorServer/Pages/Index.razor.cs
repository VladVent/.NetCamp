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
using Microsoft.AspNetCore.Http.Extensions;
using BlackJackWeb;
using BlackJack.BLL.Services;

namespace BlackJackBlazor.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ISessionService SessionService{ get; set; }
        public string identity { get; set; }
        public void Navigator(string identity)
        {
            NavigationManager.NavigateTo(String.Format("TableSessionPage/{0}", identity));
        }
    }
}