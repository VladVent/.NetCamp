using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using ConsoleApp1;
using ConsoleApp1.Logic;
using ConsoleApp1.Types;
using FluentAssertions;
using FluentAssertions.Primitives;
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
        public void SmokeTest()
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
            
            session.GetState().Players.Should().Contain(x => x.state == SuslikState.IamWon);
            

        }


        [Fact]
        public void GetStateWorks()
        {
            var session = GetFirstCombination();

            var vent = session.Join("Vent");

            session.GetState().Players.Count.Should().Be(1);
            session.GetState().Players.Single().playerName.Should().Be("Vent");


            vent.SumPoint.Should().Be(14);
            Assert.True(session.GetState().Players.Single().state == SuslikState.IamThinking);

            var petro = session.Join("Petro");
            session.GetState().Players.Count.Should().Be(2);
            petro.SumPoint.Should().Be(17);
            Assert.True(petro.state == SuslikState.IamThinking);
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
            vent.state.Should().Be(SuslikState.IamThinking);

            session.PlayerTakeCard(vent);
            session.PlayerTakeCard(vent);
            session.PlayerTakeCard(vent);
            session.PlayerTakeCard(vent);
            vent.CardsInHands.Count.Should().Be(3);
        }


        [Fact]
        public void SmokeTest3()
        {
            var session = GetFirstCombination();
            var vent = session.Join("Vent");
            session.PlayerTakeCard(vent);
            vent.SumPoint.Should().Be(24);
            session.GetState().Players.Single().cardCount.Should().Be(3);
            Assert.True(session.GetState().Players.Single().state == SuslikState.IamLost);
        }

        [Fact]
        public void FlawlessVictoryEndRound()
        {
            var session = GetSessionWithCards(
                new[] {CardName.Five, CardName.Five, CardName.Five, CardName.Ace, CardName.Ten});

            var vent = session.Join("Vent");
            var patric = session.Join("Patric");

            session.PlayerTakeCard(vent);
            vent.SumPoint.Should().Be(21);
            vent.state.Should().Be(SuslikState.IamWon);
            patric.state.Should().Be(SuslikState.IamLost);
            session.PlayerTakeCard(patric);
            patric.CardsInHands.Count.Should().Be(2);
        }


        [Fact]
        public void BothPlayersShouldBeWinnersIfDraw()
        {
            var session = GetSessionWithCards(new[]
                {CardName.Five, CardName.Five, CardName.Five, CardName.Five, CardName.Five});

            var patrick = session.Join("Patrick");
            var vent = session.Join("Vent");

            session.PlayerWouldLikeStop(patrick);
            session.PlayerWouldLikeStop(vent);

            session.GetState().Players.Should().OnlyContain(x => x.state == SuslikState.IamWon);
        }

        [Fact]
        public void PlayerLostWhenHeHasLessPoints()
        {
            var session = GetSessionWithCards(new[]
                {CardName.Five, CardName.Five, CardName.Seven, CardName.Five, CardName.Six});
            var vent = session.Join("Vent");
            var patrick = session.Join("Patrick");

            session.PlayerWouldLikeStop(vent);
            session.PlayerWouldLikeStop(patrick);
            vent.state.Should().Be(SuslikState.IamLost);
            patrick.state.Should().Be(SuslikState.IamWon);
        }


        [Fact]
        public void SessionRestartShouldHappenAfterSomebodyWon()
        {
            var session = GetSessionWithCards(new[]
                {CardName.Five, CardName.Five, CardName.Seven, CardName.Five, CardName.Six});
            var vent = session.Join("Vent");
            
            //throw new NotImplementedException();
        }


        private static TableSession GetSessionWithCards(CardName[] cards)
        {
            return new TableSession(false, GetCardStack(cards));
        }


        private static Stack<Card> GetCardStack(CardName[] array)
        {
            var cards = new Stack<Card>();
            foreach (var name in array)
                cards.Push(new Card(CardSuit.Hearts, name));
            return cards;
        }
    }
}