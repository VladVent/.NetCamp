using System.Collections.Generic;
using System.Linq;
using BlackJack.Types;

namespace BlackJack.Logic
{
    public class PlayerState
    {
        public int SessionId { get; set; }
        public string ConectionId { get; set; }

        public string Name { get; set; }
        public Stack<Card> CardsInHands { get; set; } = new Stack<Card>();
        public int SumPoint => CardsInHands.Sum(x => x.Power);
        public PlayerInGameState State { get; set; }
    }
}