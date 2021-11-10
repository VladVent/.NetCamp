using System.Collections.Generic;

namespace ConsoleApp1.Logic
{
    public class VisibleSessionState
    {
        public List<SessionsState> Players = new List<SessionsState>();
    }

    public class SessionsState
    {
        public string playerName;
        public int cardCount;
        public PlayerInGameState state;
    }

    public enum PlayerInGameState
    {
        IamDoneTakingCards,
        IamThinking,
        IamLost,
        IamWon,
    }
}