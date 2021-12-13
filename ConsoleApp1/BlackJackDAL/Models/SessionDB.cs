using BlackJack.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Models
{
    public class SessionDB
    {
        public int SessionId { get; set; }
        public List<PlayerDB>? players { get; set; }

        //public int PlayerId { get; set; }
        //public PlayerDB PlayerDB { get; set; }

        public int DeskId { get; set; }
        public DeskDB DeskDB { get; set; }
    }
}
