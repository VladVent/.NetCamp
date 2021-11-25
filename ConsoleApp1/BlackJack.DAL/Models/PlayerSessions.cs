using BlackJack.Logic;
using BlackJack.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Models
{
    public class PlayerSessions
    {
        public int SessionId { get; set; }
        public Sessions Sessions { get; set; }
        public string ConectionId { get; set; }

        public string Name { get; set; }
        public string Cards { get; set; }
        public PlayerInGameState State { get; set; }

    }
}
