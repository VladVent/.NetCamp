using System.Collections.Generic;
using System.Linq;
using BlackJack.Logic;
using BlackJack.Types;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        private static TableSession GetFirstCombination()
        {
            return new TableSession(1);
        }


        [Fact]
        public void Only4_JacksInDeckAllowed()
        {

            var deck = Deck.CreateCards();
            deck.Where(x => x.Name == nameof(CardName.JACK).ToUpper()).Should().HaveCount(4);


        }

        [Fact]
        public void JoinAndTakeCardTest()
        {
            var session = GetFirstCombination();

            var p1 = session.Join("P1");
            var p2 = session.Join("P2");
            var p3 = session.Join("P3");
            var p4 = session.Join("P4");

            session.PlayerWouldLikeStop(p1);
            session.PlayerTakeCard(p2);
            session.PlayerWouldLikeStop(p3);
            session.PlayerTakeCard(p4);
            session.PlayerWouldLikeStop(p2);
            session.PlayerWouldLikeStop(p4);

            session.GetState().Players.Should().Contain(x => x.state == PlayerInGameState.IamWon);


        }


        [Fact]
        public void GetStateWorks()
        {
            var session = GetFirstCombination();

            var vent = session.Join("Vent");

            session.GetState().Players.Count.Should().Be(1);
            session.GetState().Players.Single().playerName.Should().Be("Vent");


            vent.SumPoint.Should().Be(14);
            Assert.True(session.GetState().Players.Single().state == PlayerInGameState.IamThinking);

            var petro = session.Join("Petro");
            session.GetState().Players.Count.Should().Be(2);
            petro.SumPoint.Should().Be(17);
            Assert.True(petro.state == PlayerInGameState.IamThinking);
        }


        [Fact]
        public void PlayerWhichDecidedToStopCantTakeMoreCards()
        {
            var session = GetFirstCombination();

            var vent = session.Join("Vent");
            session.PlayerWouldLikeStop(vent);
            session.PlayerTakeCard(vent);
            vent.CardsInHands.Count.Should().Be(2);
        }


        [Fact]
        public void PlayerCantGetMoreCardsIfHeAlreadyLost()
        {
            var session = GetFirstCombination();

            var vent = session.Join("Vent");
            vent.state.Should().Be(PlayerInGameState.IamThinking);

            session.PlayerTakeCard(vent);
            session.PlayerTakeCard(vent);
            session.PlayerTakeCard(vent);
            session.PlayerTakeCard(vent);
            vent.CardsInHands.Count.Should().Be(3);
        }


        [Fact]
        public void TakeCardAndLoseTest()
        {
            var session = GetFirstCombination();
            var vent = session.Join("Vent");
            session.PlayerTakeCard(vent);
            vent.SumPoint.Should().Be(24);
            session.GetState().Players.Single().cardCount.Should().Be(3);
            vent.state.Should().Be(PlayerInGameState.IamLost);
        }

        [Fact]
        public void FlawlessVictoryEndRound()
        {
            var session = GetSessionWithCards(
                new[] { CardName.FIVE, CardName.FIVE, CardName.FIVE, CardName.ACE, CardName.TEN });

            var vent = session.Join("Vent");
            var patric = session.Join("Patric");

            session.PlayerTakeCard(vent);
            vent.SumPoint.Should().Be(21);
            vent.state.Should().Be(PlayerInGameState.IamWon);
            patric.state.Should().Be(PlayerInGameState.IamLost);
            session.PlayerTakeCard(patric);
            patric.CardsInHands.Count.Should().Be(2);
        }


        [Fact]
        public void BothPlayersShouldBeWinnersIfDraw()
        {
            var session = GetSessionWithCards(new[]
                {CardName.FIVE, CardName.FIVE, CardName.FIVE, CardName.FIVE, CardName.FIVE});

            var patrick = session.Join("Patrick");
            var vent = session.Join("Vent");

            session.PlayerWouldLikeStop(patrick);
            session.PlayerWouldLikeStop(vent);
            patrick.CardsInHands.Count.Should().Be(2);
            patrick.SumPoint.Should().Be(10);
            vent.SumPoint.Should().Be(10);
            patrick.state.Should().Be(PlayerInGameState.IamWon);
        }

        [Fact]
        public void PlayerLostWhenHeHasLessPoints()
        {
            var session = GetSessionWithCards(new[]
                {CardName.FIVE, CardName.FIVE, CardName.SEVEN, CardName.FIVE, CardName.SIX});
            var vent = session.Join("Vent");
            var patrick = session.Join("Patrick");

            session.PlayerWouldLikeStop(vent);
            session.PlayerWouldLikeStop(patrick);
            vent.state.Should().Be(PlayerInGameState.IamLost);
            patrick.state.Should().Be(PlayerInGameState.IamWon);
        }


        [Fact]
        public void SessionRestartShouldHappenAfterSomebodyWon()
        {
            var session = GetSessionWithCards(new[]
                {CardName.FIVE, CardName.FIVE, CardName.SEVEN, CardName.FIVE, CardName.SIX});
            var vent = session.Join("Vent");
            
            session.RoundNumber.Should().Be(1);
            vent.SumPoint.Should().Be(11);
            session.RestartSession();
            vent.CardsInHands.Count.Should().Be(2);
            vent.state.Should().Be(PlayerInGameState.IamThinking);
            session.PlayerWouldLikeStop(vent);
            session.RoundNumber.Should().Be(2);
            session.PlayerWouldLikeStop(vent);
            session.RestartSession();
            session.RoundNumber.Should().Be(3);
            session.PlayerWouldLikeStop(vent);
          
        }


        private static TableSession GetSessionWithCards(CardName[] cards)
        {
            return new TableSession(false, GetCardStack(cards));
        }


        private static Stack<Card> GetCardStack(CardName[] array)
        {
            var cards = new Stack<Card>();
            foreach (var name in array)
                cards.Push(new Card(CardSuit.Hearts,name.ToString(), name));
            return cards;
        }
    }
}