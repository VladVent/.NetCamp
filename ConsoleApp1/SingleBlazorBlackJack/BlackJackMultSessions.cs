using BlackJack.Logic;
using Microsoft.AspNetCore.Components;

namespace SingleBlazorBlackJack
{
    public class BlackJackMultSessions 
    {
        [Parameter]
        public TableSession tableSession { get; set; }

        public Queue<TableSession> sessions = new Queue<TableSession>();
        public void AddPlayersInSessions(string identity)
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
                StartNewSessions(identity);
            }
        }

        public void StartNewSessions(string identity)
        {
            sessions.Enqueue(tableSession);
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

        public void RestartRound(string identity)
        {
            tableSession.RestartSession();
        }

        public void PlayerWouldLikeStop(string identity)
        {
                foreach (var p in tableSession.players)
                {
                    if (p.Name == identity)
                    {
                        tableSession.PlayerWouldLikeStop(p);
                    }
                }
        }

    }
}
