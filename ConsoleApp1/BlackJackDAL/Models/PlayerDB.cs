using BlackJack.Logic;
using BlackJack.Types;

namespace BlackJack.DAL.Models
{
    public class PlayerDB
    {
        public int PlayerId { get; set; }

        public string? PlayerName { get; set; }

        // public Stack<Card> CardsInHands { get; set; } = new Stack<Card>();
        public int SumPoint { get; set; }
        public PlayerInGameState State { get; set; }

        public int SumEnemyPoint { get; set; }

        //public int SessionId { get; set; }
        //public SessionDB SessionDB { get; set; }  

        // public List<Card> ShowCardsForEnemy { get; set; }
    }
}