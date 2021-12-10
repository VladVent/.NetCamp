using System.Collections.Generic;
using System.Linq;
using BlackJack.Domain.Logic;
using BlackJack.Logic;
using BlackJack.Types;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class DeskTest
    {

        public static Desk desk = new Desk(5);

        [Fact]
        public void JoinPlayerInDesk()
        {
            desk = Casino.JoinPlayer("Name");
            desk = Casino.JoinPlayer("Derek");
            desk.tableSession.players.Should().HaveCount(2);
        }

        [Fact]
        public void JoinManyPlayersInMultySessions()
        {
            desk = Casino.JoinPlayer("Name");
            desk = Casino.JoinPlayer("Derek");

            desk.tableSession.players.Should().HaveCount(2);
            desk.tableSession.players.Any(x => x.Name == "Name").Should().BeTrue();

            desk = Casino.JoinPlayer("Patric");
            desk = Casino.JoinPlayer("Liv");
            desk.tableSession.players.Should().HaveCount(2);
            desk.tableSession.players.Any(x => x.Name == "Liv").Should().BeTrue();
            desk.tableSession.players.Any(x => x.Name == "Name").Should().BeFalse();

            desk = Casino.JoinPlayer("Deb");
            desk = Casino.JoinPlayer("a");
            desk.tableSession.players.Should().HaveCount(2);
            desk.tableSession.players.Any(x => x.Name == "Deb").Should().BeTrue();
            desk.tableSession.players.Any(x => x.Name == "Name").Should().BeFalse();
        }

        [Fact]
        public void TakeCardsInDesk()
        {
            desk = Casino.JoinPlayer("Name");
            desk = Casino.JoinPlayer("Derek");

            var players = desk.tableSession.players.FirstOrDefault(x => x.Name == "Name");
            desk.TakeCard(players.Name);
            desk.PlayerStop(players.Name);
            players.CardsInHands.Should().HaveCount(3);
        }
        [Fact]
        public void StopTakeCardInDesk()
        {
            desk = Casino.JoinPlayer("Name");
            desk = Casino.JoinPlayer("Derek");

            desk.PlayerStop("Name");
            var Name = desk.tableSession.players.FirstOrDefault(x => x.Name == "Name");
            Name.CardsInHands.Should().HaveCount(2);
            Name.State.Should().Be(PlayerInGameState.IamDoneTakingCards);
        }

        [Fact]
        public void RestartDeskRound()
        {
            desk = Casino.JoinPlayer("Name");
            desk = Casino.JoinPlayer("Derek");

            desk.PlayerStop("Name");
            desk.PlayerStop("Derek");
            var Name = desk.tableSession.players.FirstOrDefault(x => x.Name == "Name");
            var Derek = desk.tableSession.players.FirstOrDefault(x => x.Name == "Derek");

            Name.CardsInHands.Should().HaveCount(2);
            Derek.CardsInHands.Should().HaveCount(2);

            desk.tableSession.RoundNumber.Should().Be(1);
        }

    }
}
