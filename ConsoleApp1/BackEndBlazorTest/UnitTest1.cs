using Xunit;

using FluentAssertions;
using System.Linq;
using BlackJackWeb;
using SingleBlazorBlackJack;

namespace BackEndBlazorTest
{
    public class UnitTest1
    {

        private BlackJackMultSessions sessions = new BlackJackMultSessions();

        [Fact]
        public void AddPlayersInQueue()
        {
            sessions.AddPlayersInSessions("Anton");
            sessions.tableSession.GetState().Players.Count.Should().Be(1);
            sessions.AddPlayersInSessions("");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.tableSession.GetState().Players.Count.Should().Be(4);
            sessions.tableSession.GetState().Players.Any(x => x.playerName == "NoName").Should().Be(true);
        }

        [Fact]
        public void CountSessions()
        {
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.tableSession.GetState().Players.Count.Should().Be(5);

            sessions.sessions.Count.Should().Be(1);

            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Irtem");
            sessions.sessions.Count.Should().Be(2);
            sessions.tableSession.GetState().Players.Any(x => x.playerName == "Irtem").Should().Be(true);
            sessions.tableSession.GetState().Players.Count.Should().Be(5);

            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");

            sessions.tableSession.GetState().Players.Count.Should().Be(5);
            sessions.sessions.Count.Should().Be(3);


        } //Треба перевірити нормальність

        [Fact]
        public void PlayerTakeCard()
        {
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Panton");
            sessions.AddPlayersInSessions("Panton");
            sessions.AddPlayersInSessions("Panton");
            sessions.AddPlayersInSessions("Dan");

            sessions.PlayerWouldLikeTakeCard("Anton");
            // sessions.PlayerWouldLikeTakeCard("Panton");
            sessions.tableSession.GetState().Players.Count.Should().Be(5);
            sessions.sessions.Count.Should().Be(1);
            foreach (var s in sessions.sessions)
            {
                foreach (var p in s.players)
                {
                    if (p.Name == "Anton")
                    {
                        p.CardsInHands.Count.Should().Be(3);
                    }
                    else
                        p.CardsInHands.Count.Should().Be(2);
                }
            }
        }
    }
}