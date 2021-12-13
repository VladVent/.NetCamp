using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Domain.Logic
{
    public static class Casino
    {
        public static List<Desk> allAvailableTables = new List<Desk>();
        private static Desk GetOrCreateDesk(string identity)
        {
            var desk = allAvailableTables.FirstOrDefault(x => x.IsDeskPlayable());
            if (desk == null)
            {
                desk = new Desk();
                allAvailableTables.Add(desk);
            }
            desk.JoinPlayer(identity);
            return desk;
        }

        private static Desk GetOrCreateDesk(int id, string identity)
        {
            var desk = allAvailableTables.FirstOrDefault(x => x.IsDeskPlayable());
            if (desk == null)
            {
                desk = new Desk();
                allAvailableTables.Add(desk);
            }
            desk.JoinPlayer(id, identity);
            return desk;
        }

        public static Desk JoinPlayer(string identity)
        {
            return GetOrCreateDesk(identity);
        }

        public static Desk JoinPlayer(int id, string identity)
        {
            return GetOrCreateDesk(id, identity);
        }
    }


}
