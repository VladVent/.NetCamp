using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using SingleBlazorBlackJack;
using SingleBlazorBlackJack.Shared;
using System.Drawing;
using BlackJack.Domain.Logic;

namespace SingleBlazorBlackJack.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string identity { get; set; }
        public void Navigator(string identity)
        {
            NavigationManager.NavigateTo(String.Format("TableSessionPage/{0}", identity));
        }
    }
}
