using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Types;

namespace BlackJack.Logic
{
    public class TableSession
    {
        public int Id { get; set; }
        private readonly int _seed;
        public Stack<Card> deck;
        public List<PlayerState> players = new List<PlayerState>();
        public int RoundNumber { get; set; } = 1;

        public bool AllPlayersDoneTakingCards => players.All(x =>
            x.State == PlayerInGameState.IamDoneTakingCards || x.State == PlayerInGameState.IamLost);

        public bool WeHaveWinners => players.Any(x => x.State == PlayerInGameState.IamWon);

        //  public TableSession() { }

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
            player.State = ComputeState(player);

            players.Add(player);
            CheckFlawlessWin(player);
            return player;
        }
        private static PlayerInGameState ComputeState(PlayerState p)
        {

            if (p.SumPoint > 21)
                return PlayerInGameState.IamLost;

            if (p.SumPoint == 21)
                return PlayerInGameState.IamWon;
            return PlayerInGameState.IamThinking;
        }

        public void PlayerTakeCard(PlayerState playerState)
        {
            if (WeHaveWinners)
            {
                OnePlayerWin(playerState);
                return;
            }
            if (playerState.State == PlayerInGameState.IamThinking)
            {
                playerState.CardsInHands.Push(deck.GetACard());
                playerState.State = ComputeState(playerState);
            }
        }


        private void CheckFlawlessWin(PlayerState playerState)
        {
            if (playerState.State == PlayerInGameState.IamWon)
            {
                OnePlayerWin(playerState);
            }
        }

        public void OnePlayerWin(PlayerState playerState)
        {
            MakeAllPlayersLost();
            playerState.State = PlayerInGameState.IamWon;
        }

        public void PlayerWouldLikeStop(PlayerState playerState)
        {
            if (WeHaveWinners)
                return;

            if (playerState.State == PlayerInGameState.IamThinking)
                playerState.State = PlayerInGameState.IamDoneTakingCards;

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
                    w.State = PlayerInGameState.IamWon;
            }

        }


        private void MakeAllPlayersLost()
        {
            foreach (var player in players)
                player.State = PlayerInGameState.IamLost;
        }

        public void RestartSession()
        {
            RoundNumber++;
            deck = Deck.CreateCards().ShuffleDeck(Environment.TickCount);
            foreach (var p in players)
            {
                p.CardsInHands = deck.DealTheCards();
                p.State = PlayerInGameState.IamThinking;
                p.State = ComputeState(p);
            }
        }


        public VisibleSessionState GetState()
        {
            var p = new List<SessionsState>();
            foreach (var d in players)
                p.Add(new SessionsState() { playerName = d.Name, state = d.State, cardCount = d.CardsInHands.Count });
            return new VisibleSessionState() { Players = p };
        }
    }
}