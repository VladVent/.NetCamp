using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace ConsoleApp1
{
	public class TableSessions
	{
		public Stack<Card> deck = Deck.CreateCards();
		public List<Player> players = new List<Player>();


		//????
		public void GetACard(Player player)
        {
            Deck.ShuffleDeck(deck);
            if (deck.Count >= 1)
            {
			player.CardsInHands.Push(Deck.GetACard(deck));
            }
            else
            {
                WarningMassage();
            }
			player.GameRule();
            
		}

        private string WarningMassage() => "DeckIsEmpty";
       


        public void Join(Player player)
		{
			players.Add(player);
			player.CardsInHands = Deck.DealTheCards(deck);
			player.GameRule();
		}

        internal void NextTurn()
        {
            throw new NotImplementedException();
        }

        public void FinishDobora(Player p2)
        {
          
        }

        public void PlayerPoint(Player player)
        {
            player.PointMark();
            player.GameRule();
        }

        public void WinPoints(Player player)
        {
            player.WinPoints();
        }
    }
}