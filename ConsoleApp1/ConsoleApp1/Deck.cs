using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
	public static class Deck
	{
		public static Stack<Card> CreateCards()
		{
			var card = new Stack<Card>();
			foreach (var suit in Enum.GetValues(typeof(CardSuit)))
			{
				foreach (var name in Enum.GetNames(typeof(CardName)))
					card.Push(new Card((CardSuit)suit, name, (int)Enum.Parse(typeof(CardName), name)));
			}

			return card;
		}

		public static Stack<Card> ShuffleDeck(this Stack<Card> cards)
		{
			var rand = new Random();
			var values = cards.ToArray();
			cards.Clear();
			foreach (var value in values.OrderBy(x => rand.Next()))
				cards.Push(value);
			return new Stack<Card>(cards.OrderBy(x => rand.Next()));
		}


		public static Stack<Card> DealTheCards(this Stack<Card> deck)
		{
			var cardinhand = new Stack<Card>();
			for (var i = 0; i < 2 && deck.Count > 0; i++)
			{
				cardinhand.Push(deck.Pop());
			}

			return cardinhand;
		}

		public static Card GetACard(this Stack<Card> deck)
		{
			return deck.Pop();
		}
	}
}