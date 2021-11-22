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

//public string Name = string.Empty;
//public string State = string.Empty;
//public string Sum = string.Empty;
//public string SumScore = string.Empty;

namespace BlackJackBlazor.Pages
{
    public class TableSessionsPage : ComponentBase
    {
        [Parameter]
        public string Identity { get; set; }
        public TableSession tableSession { get; set; }

        public Queue<TableSession> sessions = new Queue<TableSession>();

        public TableSession AddPlayersInSessions(string identity)
        {
            if (sessions.Count == 0)
            {
                tableSession = new TableSession(Environment.TickCount);
                sessions.Enqueue(tableSession);
            }
            var players = tableSession.players;
            if (identity == "")
            {
                identity = "NoName";
            }
            if (players == null || players.Count < 6) // може пропустити 6 гравц€, €кщо нема йому супротивника. якщо знайдетьс€ його перекине в нову сес≥ю.
            {
                tableSession.Join(identity);
            }
            else
            {
                sessions.Enqueue(tableSession);
                StartNewSessions(identity);
            }
            return tableSession;
        }

        public void StartNewSessions(string identity)
        {
            tableSession = new TableSession(Environment.TickCount);
            tableSession.Join(identity);
            AddPlayersInSessions(identity);
        }
        public string TakeStats = string.Empty;
        public string TakeSumScore()
        {
            foreach(var p in tableSession.players)
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
    }
}