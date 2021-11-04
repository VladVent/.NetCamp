using System.Collections.Generic;

namespace ConsoleApp1.Logic
{
    public class VisibleSessionState
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