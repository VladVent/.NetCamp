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
        public Stack<CardSDB> deck { get; set; }

        public int IdCard { get; set; }
        public CardSDB CardSDB { get; set; }
        public List<PlayerDB>? players { get; set; }

        public int PlayerId { get; set; }
        public PlayerDB PlayerDB { get; set; }  
    }
}
