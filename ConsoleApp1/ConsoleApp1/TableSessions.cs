using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
	public class TableSessions
	{
		private IGameRuleState gameRuleState;
		public Stack<Card> deck = Deck.CreateCards().ShuffleDeck();
		public List<Player> players = new List<Player>();

		public TableSessions() => this.gameRuleState = new ConsoleStatePrinter();

		public void Join(Player player)
		{
			players.Add(player);
		}

		public void DealCard(Player player)
		{
			player.CardsInHands = deck.DealTheCards();
			player.Skip = false;
		}


		public void IWillSkipSuslik(Player player)
		{
			player.Skip = true;
		}

		public void GetACard(Player player)
		{
			if(player.Lost)
				return;
			

			player.CardsInHands.Push(deck.GetACard());
			CheckGameRules();
		}

		public void CheckGameRules()
		{
			var sorted = players
				.Where(x => x.SumPoint <= 21)
				.OrderBy(x => x.SumPoint);

			var last = sorted.Last();

			var loosers = players.Where(x => x.SumPoint > 21);
			var allWinners = sorted.Where(x => x.SumPoint == last.SumPoint);


			gameRuleState.Win(allWinners);
			gameRuleState.GameOver(loosers);


			if (allWinners.Count() == players.Count)
				gameRuleState.Draw(allWinners);
		}


		public void RestartRound()
		{
			deck = Deck.CreateCards().ShuffleDeck();

			foreach (var p in players)
			{
				DealCard(p);
			}
		}

		public bool DeckIsEmpty() => deck.Count > 0;
	}
}