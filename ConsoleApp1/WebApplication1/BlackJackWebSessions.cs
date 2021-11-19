using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.Logic;


//Environment.TickCount

namespace BlackJackWeb
{
    public class BlackJackWebSessions
    {
        public TableSession tableSession = new TableSession(Environment.TickCount);

        public void AddPlayersInSessions(string identity)
        {
            var players = tableSession.GetState();
            if (identity == "")
            {
                identity = "NoName";
            }
            if (players == null || players.Players.Count < 6) // може пропустити 6 гравця, якщо нема йому супротивника. Якщо знайдеться його перекине в нову сесію.
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
            tableSession = new TableSession(Environment.TickCount);
            tableSession.Join(identity);
            AddPlayersInSessions(identity);
        }

        public void PlayerWouldLikeTakeCard(string identity)
        {
            
        }



    }
}
