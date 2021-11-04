using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class TableSessions
    {
        private readonly int _seed;
        private readonly Stack<Card> deck;
        private List<Player> players = new List<Player>();


        public TableSessions(int seed)
        {
            _seed = seed;
            deck = Deck.CreateCards().ShuffleDeck(_seed);
        }

        public TableSessions()
        {
            deck = Deck.CreateCards().ShuffleDeck(Environment.TickCount);
        }



        public Player Join(string p)
        {
            var player = new Player
            {
                Name = p,
                CardsInHands = deck.DealTheCards(),
            };

            player.state = ComputeState(player);
            players.Add(player);
            return player;
        }

        private static SuslikState ComputeState(Player p)
        {
            if (p.SumPoint > 21)
                return SuslikState.IamLost;

            if (p.SumPoint == 21)
                return SuslikState.IamWon;

            return SuslikState.IamThinking;
        }

        public void PlayerTakeCard(Player player)
        {
            if (player.state == SuslikState.IamThinking)
            {
                player.CardsInHands.Push(deck.GetACard());
                player.state = ComputeState(player);
            }

        }


        public void PlayerWouldLikeStop(Player player)
        {
            if (player.state == SuslikState.IamThinking)
                player.state = SuslikState.IamDoneTakingCards;
        }



        public VisibleState GetState()
        {
            var p = new List<Suslik>();
            foreach (var d in players)
            {
                p.Add(new Suslik() { playerName = d.Name, state = d.state, cardCount = d.CardsInHands.Count });
            }
            return new VisibleState() { Players = p };
        }
    }
}