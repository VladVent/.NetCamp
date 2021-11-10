using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Types;

namespace ConsoleApp1.Logic
{
    public class PlayerState
    {
        public string Name { get; set; }
        public Stack<Card> CardsInHands = new Stack<Card>();
        public int SumPoint => CardsInHands.Sum(x => x.Power);
        public PlayerThinksState state { get; set; }
    }
}