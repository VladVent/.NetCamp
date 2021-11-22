using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.Logic;
using Microsoft.AspNetCore.Components;


//Environment.TickCount

namespace BlackJackWeb
{
    public class BlackJackWebSessions
    {
        [Parameter]
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
            if (players == null || players.Count < 6) // може пропустити 6 гравця, якщо нема йому супротивника. Якщо знайдеться його перекине в нову сесію.
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

        public void PlayerWouldLikeTakeCard(string identity)
        {
            foreach (var sessionPlayers in sessions)
            {
                var players = sessionPlayers.players;
                foreach (var p in players)
                {
                    if (p.Name == identity)
                    {
                        sessionPlayers.PlayerTakeCard(p);
                    }
                }
            }

        }

        public void GetState(string identity)
        {
            var player = tableSession.GetState().Players;
            foreach (var p in player)
            {
                identity = p.playerName;
            }
        }

        public void PlayerWouldLikeStop(string identity)
        {
            foreach (var sessionPlayers in sessions)
            {
                var players = sessionPlayers.players;
                foreach (var p in players)
                {
                    if (p.Name == identity)
                    {
                        sessionPlayers.PlayerWouldLikeStop(p);
                    }
                }
            }
        }

    }
}
