using System.Collections.Generic;

namespace ConsoleApp1
{
	public interface IGameRuleMessage
	{
		void CleanWin();
		void PlayerLoseMessage(IEnumerable<Player> enumerable);
		void PlayerWinMessage(IEnumerable<Player> allWinners);
		void PlayersDrawMessage(IEnumerable<Player> allWinners);
	}
}   