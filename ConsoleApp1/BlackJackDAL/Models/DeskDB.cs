using BlackJack.Logic;
using BlackJack.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Models
{
    public class DeskDB
    {
        public int DeskId { get; set; }
        public SessionDB? TableSession { get; set; }
        // public CasinoDB? CasinoDB { get; set;}
    }
}
