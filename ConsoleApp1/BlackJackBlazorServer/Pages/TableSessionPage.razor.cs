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

namespace BlackJackBlazor.Pages
{
    public class TableSessionsPage : ComponentBase
    {
        [Parameter]
        public string Identity { get; set; }

        public IndexModel index = new IndexModel();


        public string Name = string.Empty;
        public string State = string.Empty;
        public string Sum = string.Empty;
        public string SumScore = string.Empty;

        public string ShowStates()
        {
            var sessions = index.blackJackSessions.tableSession.GetState().Players;
            foreach (var session in sessions)
            {
                Name = session.playerName;
               
            }
            return Name;
        }
        public void ShowSumScore()
        {
            var playersSum = index.blackJackSessions.tableSession.players;
            foreach (var player in playersSum)
            {
                SumScore = player.SumPoint.ToString();
            }
        }
    }
}