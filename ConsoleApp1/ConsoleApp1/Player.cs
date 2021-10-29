using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public class Player
    {
        private IGameRuleState gameRuleState;
        public string Name { get; set; }
        public Stack<Card> CardsInHands = new Stack<Card>();
        public int SumPoint;
        public bool Exact21Point() => PointMark() == 21;
        public bool BeyondPointMark() => PointMark() > 21;
        public bool RountCheck() => PointMark() < 21;

        public Player() => this.gameRuleState = new GameCleanWin();
    
        public int PointMark()
        {
            return SumPoint = CardsInHands.Sum(x => x.Power);
        }

        public void GameRule()
        {
            if (BeyondPointMark())
                gameRuleState.GameOver();

            if (Exact21Point())
                gameRuleState.CleanWin();
        }
    }
}