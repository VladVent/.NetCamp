using BlackJack.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack.Domain.Logic
{

    /// <summary>
    /// Black jack desk with session and players.
    /// </summary>
    public class Desk
    {
        private readonly int _seed;

        public int DeskId { get; set; }
        public TableSession TableSession { get; private set; }
        public event EventHandler DeskStateUpdated;

        public Desk()
        {
            TableSession = new TableSession(Environment.TickCount);
        }

        public Desk(int seed)
        {
            _seed = seed;
            TableSession = new TableSession(_seed); ;
        }

        public bool IsDeskPlayable(string id)
        {
            return GetArrayPlayers().Count() < 2 && !IsPlayerInSession(id) ? true : false;
        }

        public void TakeCard(string id)
        {
            TableSession.PlayerTakeCard(TakePlayer(id));
            DoSessionStateUpdated();
        }

        public async void JoinPlayer(string identity)
        {
            TableSession.Join(identity);
            DoSessionStateUpdated();
            await AllPlayersStop();
        }

        public async void JoinPlayer(int id, string identity)
        {
            TableSession.Join(id, identity);
            DoSessionStateUpdated();
            await AllPlayersStop();
        }

        public async void PlayerStop(string id)
        {
            TableSession.PlayerWouldLikeStop(TakePlayer(id));
            DoSessionStateUpdated();
            await AllPlayersStop();
        }

        public List<PlayerState> GetArrayPlayers()
        {
            return TableSession.players;
        }


        private async Task AllPlayersStop()
        {
            var isAnyPlayerWinRound = IsTakeWinnerOrLoser();
            if (isAnyPlayerWinRound)
            {
                await Task.Delay(5000);
                RestartRound();
            }
        }

        private bool IsTakeWinnerOrLoser()
        {
            return GetArrayPlayers().Any(x => x.State == PlayerInGameState.IamWon || x.State == PlayerInGameState.IamLost);
        }

        private void RestartRound()
        {
            TableSession.RestartSession();
            DoSessionStateUpdated();
        }

        private bool IsPlayerInSession(string id) => GetArrayPlayers().Any(x => x.PlayerName == id);
        private PlayerState TakePlayer(string id)
        {
            return GetArrayPlayers().FirstOrDefault(x => x.PlayerName == id);
        }


        private void DoSessionStateUpdated()
        {
            DeskStateUpdated?.Invoke(this, EventArgs.Empty);
        }

    }
}
