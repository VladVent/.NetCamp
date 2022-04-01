using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Domain.Logic
{
    public static class Casino
    {
        public static List<Desk> allAvailableTables = new List<Desk>();
        private static Desk GetOrCreateDesk(string identity)
        {
            var desk = allAvailableTables.FirstOrDefault(x => x.IsDeskPlayable(identity));
            if (desk == null)
            {
                desk = new Desk();
                allAvailableTables.Add(desk);
            }
            desk.JoinPlayer(identity);
            return desk;
        }

      
        public static Desk JoinPlayer(string identity)
        {
            return GetOrCreateDesk(identity);
        }

    }


}
