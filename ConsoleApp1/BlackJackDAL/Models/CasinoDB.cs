using BlackJack.Domain.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Models
{
    public class CasinoDB
    {
        public IEnumerable<DeskDB>? AllTables { get; set; }

        public int DeskId { get; set; }
        public DeskDB Desk { get; set; }
    }
}
