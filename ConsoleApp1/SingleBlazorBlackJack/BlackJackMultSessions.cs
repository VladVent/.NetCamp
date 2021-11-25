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

            tableSession =  GetOrCreateSession(identity);
            return (tableSession, tableSession.players.FirstOrDefault(x => x.Name == identity));
        }

        public TableSession GetOrCreateSession(string identity)
        {
            var s = allAvailableSessions.FirstOrDefault(x => x.players.Any(p => p.Name != null) && x.players.Count < 2);
            if (s == null)
            {
                s =  new TableSession(Environment.TickCount);
                s.Join(identity);
                allAvailableSessions.Add(s);
            }
            else
            {
                s.Join(identity);
            }
            return s;
        }
    }
}
