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
            desk.TableSession.players.Should().HaveCount(2);
        }

        [Fact]
        public void JoinManyPlayersInMultySessions()
        {
            desk = Casino.JoinPlayer("Name");
            desk = Casino.JoinPlayer("Derek");

            desk.TableSession.players.Should().HaveCount(2);
            desk.TableSession.players.Any(x => x.PlayerName == "Name").Should().BeTrue();

            desk = Casino.JoinPlayer("Patric");
            desk = Casino.JoinPlayer("Liv");
            desk.TableSession.players.Should().HaveCount(2);
            desk.TableSession.players.Any(x => x.PlayerName == "Liv").Should().BeTrue();
            desk.TableSession.players.Any(x => x.PlayerName == "Name").Should().BeFalse();

            desk = Casino.JoinPlayer("Deb");
            desk = Casino.JoinPlayer("a");
            desk.TableSession.players.Should().HaveCount(2);
            desk.TableSession.players.Any(x => x.PlayerName == "Deb").Should().BeTrue();
            desk.TableSession.players.Any(x => x.PlayerName == "Name").Should().BeFalse();
        }

        [Fact]
        public void TakeCardsInDesk()
        {
            desk = Casino.JoinPlayer("Name");
            desk = Casino.JoinPlayer("Derek");

            var players = desk.TableSession.players.FirstOrDefault(x => x.PlayerName == "Name");
            desk.TakeCard(players.PlayerName);
            desk.PlayerStop(players.PlayerName);
        }
        [Fact]
        public void StopTakeCardInDesk()
        {
            desk = Casino.JoinPlayer("Name");
            desk = Casino.JoinPlayer("Derek");

            desk.PlayerStop("Name");
            var Name = desk.TableSession.players.FirstOrDefault(x => x.PlayerName == "Name");
            Name.CardsInHands.Should().HaveCount(2);
          //  Name.State.Should().Be(PlayerInGameState.IamDoneTakingCards);
        }

        [Fact]
        public void RestartDeskRound()
        {
            desk = Casino.JoinPlayer("Name");
            desk = Casino.JoinPlayer("Derek");

            desk.PlayerStop("Name");
            desk.PlayerStop("Derek");
            var Name = desk.TableSession.players.FirstOrDefault(x => x.PlayerName == "Name");
            var Derek = desk.TableSession.players.FirstOrDefault(x => x.PlayerName == "Derek");

            Name.CardsInHands.Should().HaveCount(2);
            Derek.CardsInHands.Should().HaveCount(2);

            desk.TableSession.RoundNumber.Should().Be(1);
        }

    }
}
