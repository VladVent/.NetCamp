﻿using System;
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
        public int Point;

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
                } //костиль Не впевнений чи зможу це спростити.
            }
        }

        public void CheckRound()
        {
            GameRules();
              //  Console.WriteLine($"{p.Name}: {Point}");
        }


        public int WinPoints() => Point = 0;
        
        public bool DeckIsEmpty() => deck.Count >= 1;
    }
}