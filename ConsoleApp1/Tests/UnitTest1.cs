
using System;
using System.Diagnostics;
using System.Linq;
using ConsoleApp1;
using FluentAssertions;
using FluentAssertions.Primitives;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {


        private static TableSessions GetFirstCombination()
        {
            return new TableSessions(1);
        }

        [Fact]
        public void SmokeTest()
        {
            var session = GetFirstCombination();
            var vent = session.Join("Vent");
            vent.CardsInHands.Count.Should().Be(2);
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
        public void FlawlessPlayerWinEndRound()
        {
            var session = new TableSessions();

            var vent = session.Join("Vent");
            var patric = session.Join("Patric");

            session.GetState().Players.Count.Should().Be(2);

            vent.SumPoint.Should().Be(21);
            patric.SumPoint.Should().Be(20);
            session.PlayerTakeCard(patric);
            session.GetState().Players.Last().cardCount.Should().Be(3);
            Assert.True(session.GetState().Players.Single().state == SuslikState.GameIsDone);
        }
    }
}
