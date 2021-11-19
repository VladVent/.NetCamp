using Xunit;
using BlackJackWeb;
using FluentAssertions;
using System.Linq;
namespace BackEndBlazorTest
{
    public class UnitTest1
    {

        private BlackJackWebSessions sessions = new BlackJackWebSessions();

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


            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");


            sessions.tableSession.GetState().Players.Count.Should().Be(5);
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.AddPlayersInSessions("Anton");
            sessions.tableSession.GetState().Players.Count.Should().Be(5);



        } //Треба перевірити нормальність

        [Fact]
        public void PlayerTakeCard()
        {

        }
    }
}