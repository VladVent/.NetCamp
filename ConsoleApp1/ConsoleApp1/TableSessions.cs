using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace ConsoleApp1
{
    public class TableSessions
    {
        public Stack<Card> deck = Deck.CreateCards().ShuffleDeck();
        public List<Player> players = new List<Player>();
        public int Point { get; set; }

        public void GetACard(Player player)
        {
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

        public int CheckRount()
        {
            foreach (var p in players)
            {
                if (p.PointMark()<=21)
                {
                   p.Win();
                   WinPoints();
                }
                else
                {
                    p.GameOver();
                }
            }

            return Point;

        }

       // public Stack<Card> ShowCard(Player player) => player.CardsInHands;
        
        public int WinPoints() => Point += 1;

        public bool DeckIsEmpty() => deck.Count >= 1;
    }
}