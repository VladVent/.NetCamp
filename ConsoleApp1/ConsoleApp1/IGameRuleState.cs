using System.Collections.Generic;

namespace ConsoleApp1
{
	public interface IGameRuleState
	{
		void CleanWin();
		void GameOver(IEnumerable<Player> enumerable);
		void Win(IEnumerable<Player> allWinners);
		void Draw(IEnumerable<Player> allWinners);
	}
}