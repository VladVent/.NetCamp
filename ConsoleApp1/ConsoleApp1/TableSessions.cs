using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    public class TableSessions
    {
        private IGameRuleState gameRuleState;
        public Stack<Card> deck = Deck.CreateCards().ShuffleDeck();
        public List<Player> players = new List<Player>();

        public TableSessions() => this.gameRuleState = new GameRule();

        public void Join(Player player)
        {
            players.Add(player);
        }

        public void DealCard(Player player)
        {
            player.CardsInHands = Deck.DealTheCards(deck);
            player.PointMark();
        }
        public void GetACard(Player player)
        {
            player.CardsInHands.Push(Deck.GetACard(deck));
                player.PointMark();
        }

        public void GameRules()
        {
            //var player = players.OrderBy(x => x.SumPoint > 21 ? 0: x.SumPoint).LastOrDefault();

            //if (player.SumPoint != 0)
            //    gameRuleState.Win();

            var MaxPoint = players.Max(t => t.SumPoint);
            var MinPoint = players.Min(t => t.SumPoint);

            foreach (var p in players)
            {
                var _sumpoint = p.SumPoint;
                if (_sumpoint == 21)
                {
                    gameRuleState.CleanWin();
                    break;
                }
                else
                {
                    if (MaxPoint < 21 && _sumpoint.Equals(MaxPoint) || MaxPoint > 21 && MaxPoint > _sumpoint)
                    {
                        if (MinPoint.Equals(MaxPoint))
                        {
                            gameRuleState.Draw();
                            break;
                        }
                        else
                        {
                            gameRuleState.Win();
                        }
                    }
                    else
                    {
                        gameRuleState.GameOver();
                    }
                }
            }//Костиль виграв-програв.
        }//КОСТИЛЬ!!!!

        public void CheckRound()
        {
            
            GameRules();
            foreach (var p in players)
            {
                while (p.CardsInHands.Count != 0)
                {
                deck.Push(p.CardsInHands.Pop());
                }
                Console.WriteLine($"COUNT: {deck.Count}");
            }
            deck.ShuffleDeck();
        }
        public bool DeckIsEmpty() => deck.Count >= 1;
    }
}