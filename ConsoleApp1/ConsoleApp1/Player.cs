using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
	public class Player
	{
		public string Name { get; set; }
		public Stack<Card> CardsInHands = new Stack<Card>();

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
				YouAreWinner();
		}


		public string YouAreWinner()=> "GG WP!";
      

		public string GameOver() => "Loser!";
      
	}
}