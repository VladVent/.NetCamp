using BlackJack.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Models
{
    public class CardSDB
    {
        public int IdCard { get;set; }
        public CardSuit CardSuit { get; set; }
        public int Power { get; set; }
        public string Name { get; set; }

        public SessionDB SessionDB { get; set; }
    }
}
