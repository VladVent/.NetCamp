using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
	public class Player
	{
		public string Name { get; set; }
		public Stack<Card> CardsInHands = new Stack<Card>();
        public int Point;
		public bool Exact21Point() => PointMark() == 21;
		public bool BeyondPointMark() => PointMark() > 21;

		public int PointMark()
		{
			return CardsInHands.Sum(x => x.Power);
		}


		public void GameRule()
		{
			if (BeyondPointMark())
				GameOver();

            if (Exact21Point())
                //WinPoints();
                CleanWin();

        }

      
       public int WinPoints() => Point += 1;

       public string CleanWin() => "GG EZ!";
       public string GameOver() => "Loser!";
      
	}
}