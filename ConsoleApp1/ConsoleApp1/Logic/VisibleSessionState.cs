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
        public PlayerThinksState state;
    }

    public enum PlayerThinksState
    {
        IamDoneTakingCards,
        IamThinking,
        IamLost,
        IamWon,
    }
}