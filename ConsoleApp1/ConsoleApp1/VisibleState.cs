using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class VisibleState
    {
        public List<Suslik> Players = new List<Suslik>();


    }

    public class Suslik
    {
        public string playerName;
        public int cardCount;
        public SuslikState state;


    }

    public enum SuslikState
    {
        IamDoneTakingCards,
        IamThinking,
        IamLost,
        IamWon,
    }
}
