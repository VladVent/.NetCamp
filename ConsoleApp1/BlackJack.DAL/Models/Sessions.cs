using BlackJack.Logic;
using BlackJackWeb;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Models
{
    public class Sessions
    {
        public int Id { get; set; }
        public string Cards { get; set; }
        public List<PlayerSessions> PlayerSessions { get; set; }
    }
}
