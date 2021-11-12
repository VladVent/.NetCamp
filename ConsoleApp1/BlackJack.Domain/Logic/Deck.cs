using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Types;

namespace BlackJack.Logic
{
	public static class Deck
	{
		public static Stack<Card> CreateCards()
		{
			var card = new Stack<Card>();
			foreach (var suit in Enum.GetValues(typeof(CardSuit)))
			{
				foreach (var name in Enum.GetNames(typeof(CardName)))
                {
                    card.Push(new Card((CardSuit)suit, name,(CardName)Enum.Parse(typeof(CardName),name)));

                }

            }

			return card;
		}

		public static Stack<Card> ShuffleDeck(this Stack<Card> cards, int seed)
		{
			var rand = new Random(seed);
			var values = cards.ToArray();
			cards.Clear();
			foreach (var value in values.OrderBy(x => rand.Next()))
				cards.Push(value);
			return new Stack<Card>(cards.OrderBy(x => rand.Next()));
		}

        public static Stack<Card> DealTheCards(this Stack<Card> deck)
		{
			var cardsinhand = new Stack<Card>();
			for (var i = 0; i < 2 && deck.Count > 0; i++)
			{
                cardsinhand.Push(deck.Pop());
			}

			return cardsinhand;
		}

		public static Card GetACard(this Stack<Card> deck)
		{
			return deck.Pop();
		}
	}
}