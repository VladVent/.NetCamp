using System.Collections.Generic;
using System.Linq;
using BlackJack.Types;

namespace BlackJack.Logic
{
    public sealed class PlayerState
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public Stack<Card> CardsInHands { get; set; } = new Stack<Card>();
        public int SumPoint => CardsInHands.Sum(x => x.Power);
        public PlayerInGameState State { get; set; }

        public int ShowPointForEnemy => CardsInHands.Skip(1).Sum(x => x.Power);

        public List<Card> ShowCardsForEnemy => CardsInHands.Skip(1).ToList();

    }
}