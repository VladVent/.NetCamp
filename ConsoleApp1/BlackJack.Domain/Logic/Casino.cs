using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Domain.Logic
{
    public static class Casino
    {
        private static List<Desk> allAvailableTables = new List<Desk>();
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


        public static Desk JoinPlayer(string identity)
        {
            return GetOrCreateDesk(identity);
        }

        public static List<Desk> GetDesks => allAvailableTables.ToList();
    }


}
