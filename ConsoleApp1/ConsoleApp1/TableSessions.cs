using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace ConsoleApp1
{
    public class TableSessions
    {
        private IGameRuleState gameRuleState;
        public Stack<Card> deck = Deck.CreateCards().ShuffleDeck();
        public List<Player> players = new List<Player>();
        public int Point { get; set; }
        public TableSessions() => this.gameRuleState = new GameRule();
            
        public void Join(Player player)
        {
            players.Add(player);
        }

        public void DealCard(Player player)
        {
            player.CardsInHands = Deck.DealTheCards(deck);
            player.PointMark();
            //GameRule();
        }
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
            player.PointMark();
        }

        private string WarningMassage() => "DeckIsEmpty";


        public void GameRule()
        {
            foreach (var p in players)
            {
                if (p.SumPoint > 21)
                    gameRuleState.GameOver();

                if (p.SumPoint == 21)
                    gameRuleState.CleanWin();
                if (players.Max(t => t.SumPoint) <  p.PointMark() )
                {
                    gameRuleState.Win();
                }
            }
        }

        public int CheckRound()
        {
            foreach (var p in players)
            {
                if (p.SumPoint == players.Max(t=>t.SumPoint) )
                {
                   GameRule();
                   WinPoints();
                }
                else
                {
                   gameRuleState.GameOver();
                }
            }
            return Point;
        }

        public int WinPoints() => Point += 1;

        public bool DeckIsEmpty() => deck.Count >= 1;
    }
}