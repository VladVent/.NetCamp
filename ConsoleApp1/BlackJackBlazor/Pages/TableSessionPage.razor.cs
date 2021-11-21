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

namespace BlackJackBlazor.Pages
{
    public partial class TableSessionsPage : ComponentBase
    {
        public Index index = new Index();


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