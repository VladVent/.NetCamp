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
        public string PlayerId { get; set; }
    }
}
