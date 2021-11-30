using BlackJack.Logic;
using Microsoft.AspNetCore.Components;

namespace SingleBlazorBlackJack
{
    public class BlackJackMultSessions
    {
        public TableSession tableSession { get; set; }


        private static List<TableSession> allAvailableSessions = new();


        public (TableSession, PlayerState) GetPlayerAndSession(string identity)
        {

            tableSession = GetOrCreateSession(identity);
            return (tableSession, tableSession.players.FirstOrDefault(x => x.Name == identity));
        }

        public TableSession GetOrCreateSession(string identity)
        {
            var s = allAvailableSessions.FirstOrDefault(x => x.players.Any(p => p.Name != null) && x.players.Count < 2);
            if (s == null)
            {
                s = new TableSession(Environment.TickCount);
                s.Join(identity);
                allAvailableSessions.Add(s);
            }
            else
            {
                s.Join(identity);
            }
            return s;
        }

        public void TakeCard(string id)
        {
            tableSession.PlayerTakeCard(TakePlayer(id));
        }

        public void RestartRound()
        {
            tableSession.RestartSession();
        }

        public void PlayerStop(string id)
        {
            tableSession.PlayerWouldLikeStop(TakePlayer(id));
        }

        private PlayerState? TakePlayer(string id)
        {
            return tableSession.players.Where(x => x.Name == id).FirstOrDefault();
        }
    }

    public static class Container
        {
        public static BlackJackMultSessions BlackJack = new BlackJackMultSessions();
        }
}
