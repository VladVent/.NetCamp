using BlackJack.Logic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Domain.Logic
{

    /// <summary>
    /// Black jack desk with session and players.
    /// </summary>
    public sealed class Desk
    {
        public TableSession tableSession { get; private set; }
        public event EventHandler DeskStateUpdated;

        public Desk()
        {
            tableSession = new TableSession(Environment.TickCount);
        }



        public void TakeCard(string id)
        {
            tableSession.PlayerTakeCard(TakePlayer(id));
            DoSessionStateUpdated();
        }


        public void JoinPlayer(string identity)
        {
            tableSession.Join(identity);
            DoSessionStateUpdated();
        }

        public async void PlayerStop(string id)
        {
            tableSession.PlayerWouldLikeStop(TakePlayer(id));
            DoSessionStateUpdated();
            await AllPlayersStop();
        }

        private async Task AllPlayersStop()
        {
            var isAnyPlayerWinRound = tableSession.players.Any(x => x.State == PlayerInGameState.IamWon);
            if (isAnyPlayerWinRound)
            {
                await Task.Delay(5000);
                RestartRound();
            }
        }

        private void RestartRound()
        {
            tableSession.RestartSession();
            DoSessionStateUpdated();
        }
        private PlayerState TakePlayer(string id)
        {
            return tableSession.players.Where(x => x.Name == id).FirstOrDefault();
        }

        private void DoSessionStateUpdated()
        {
            DeskStateUpdated?.Invoke(this, EventArgs.Empty);
        }

        internal bool IsDeskPlayable()
        {
            return true;
        }

    }
}
