using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Types;

namespace ConsoleApp1.Logic
{
    public class TableSession
    {
        private readonly int _seed;
        private Stack<Card> deck;
        private List<PlayerState> players = new List<PlayerState>();
        public int RoundNumber { get; private set; } = 1;

        public bool AllPlayersDoneTakingCards => players.All(x =>
            x.state == PlayerThinksState.IamDoneTakingCards || x.state == PlayerThinksState.IamLost);

        public bool WeHaveWinners => players.Any(x => x.state == PlayerThinksState.IamWon);


        public TableSession(int seed)
        {
            _seed = seed;
            deck = Deck.CreateCards().ShuffleDeck(_seed);
        }

        public TableSession(bool shuffleDeck, Stack<Card> cards)
        {
            deck = cards;
            if (shuffleDeck)
                deck = deck.ShuffleDeck(Environment.TickCount);
        }


        public PlayerState Join(string p)
        {
            var player = new PlayerState
            {
                Name = p,
                CardsInHands = deck.DealTheCards(),
            };
            player.state = ComputeState(player);

            players.Add(player);
            CheckFlawlessWin(player);
            return player;
        }

        private static PlayerThinksState ComputeState(PlayerState p)
        {

            if (p.SumPoint > 21)
                return PlayerThinksState.IamLost;

            if (p.SumPoint == 21)
                return PlayerThinksState.IamWon;
            return PlayerThinksState.IamThinking;
        }

        public void PlayerTakeCard(PlayerState playerState)
        {

            if (WeHaveWinners)
            {
                OnePlayerWin(playerState);
                return;
            }
            if (playerState.state == PlayerThinksState.IamThinking)
            {
                playerState.CardsInHands.Push(deck.GetACard());
                playerState.state = ComputeState(playerState);
            }
        }


        private void CheckFlawlessWin(PlayerState playerState)
        {
            if (playerState.state == PlayerThinksState.IamWon)
            {
                OnePlayerWin(playerState);
            }
        }

        private void OnePlayerWin(PlayerState playerState)
        {
            MakeAllPlayersLost();
            playerState.state = PlayerThinksState.IamWon;
        }

        public void PlayerWouldLikeStop(PlayerState playerState)
        {
            if (WeHaveWinners)
                return;

            if (playerState.state == PlayerThinksState.IamThinking)
                playerState.state = PlayerThinksState.IamDoneTakingCards;

            if (!AllPlayersDoneTakingCards)
                return;


            var sorted = players
                .Where(x => x.SumPoint <= 21)
                .OrderBy(x => x.SumPoint);


            MakeAllPlayersLost();
            if (sorted.Any())
            {
                
                var last = sorted.Last();
                var allWinners = sorted.Where(x => x.SumPoint == last.SumPoint);
                foreach (var w in allWinners)
                    w.state = PlayerThinksState.IamWon;
            }

        }


        private void MakeAllPlayersLost()
        {
            foreach (var player in players)
                player.state = PlayerThinksState.IamLost;
        }

        public void RestartSession()
        {
            RoundNumber++;
            deck = Deck.CreateCards().ShuffleDeck(Environment.TickCount);
            foreach (var p in players)
            {
                p.CardsInHands = deck.DealTheCards();
                p.state = PlayerThinksState.IamThinking;
                p.state = ComputeState(p);
            }

        }


        public VisibleSessionState GetState()
        {
            var p = new List<Suslik>();
            foreach (var d in players)
                p.Add(new Suslik() { playerName = d.Name, state = d.state, cardCount = d.CardsInHands.Count });
            return new VisibleSessionState() { Players = p };
        }
    }
}