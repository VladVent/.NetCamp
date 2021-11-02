using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
	public class ConsoleStatePrinter : IGameRuleState
	{
		public void CleanWin()
		{
			Console.WriteLine("GG EZ!!!!");
		}

		public void GameOver(IEnumerable<Player> enumerable)
		{
			Console.WriteLine("Loosers:" + NamesToSingleString(enumerable));
		}

		private static string NamesToSingleString(IEnumerable<Player> enumerable)
		{
			return string.Join(",", enumerable.Select(x => x.Name));
		}

		public void Win(IEnumerable<Player> allWinners)
		{
			Console.WriteLine("Winners:" + NamesToSingleString(allWinners));
		}

		public void Draw(IEnumerable<Player> allWinners)

		{
			Console.WriteLine("Draw players:" + NamesToSingleString(allWinners));
		}
	}
}