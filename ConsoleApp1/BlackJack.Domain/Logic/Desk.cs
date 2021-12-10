﻿using BlackJack.Logic;
using System;
using System.Collections.Generic;
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
        public event EventHandler ReloadRoundMessage;

        public Desk()
        {
            tableSession = new TableSession(Environment.TickCount);
        }

        internal bool IsDeskPlayable()
        {
            return GetArrayPlayers().Count() < 2 ? true : false;
        }

        public void TakeCard(string id)
        {
            tableSession.PlayerTakeCard(TakePlayer(id));
            DoSessionStateUpdated();
        }

        public async void JoinPlayer(string identity)
        {
            tableSession.Join(identity);
            DoSessionStateUpdated();
            await AllPlayersStop();
        }

        public async void PlayerStop(string id)
        {
            tableSession.PlayerWouldLikeStop(TakePlayer(id));
            DoSessionStateUpdated();
            await AllPlayersStop();
        }

        public List<PlayerState> GetArrayPlayers()
        {
            return tableSession.players;
        }


        private async Task AllPlayersStop()
        {
            var isAnyPlayerWinRound = IsTakeWinner();
            if (isAnyPlayerWinRound)
            {
                ReloadindRoundMessage();
                await Task.Delay(5000);
                RestartRound();
            }
        }

        private bool IsTakeWinner()
        {
            return GetArrayPlayers().Any(x => x.State == PlayerInGameState.IamWon);
        }

        private void RestartRound()
        {
            tableSession.RestartSession();
            DoSessionStateUpdated();
        }
        private PlayerState TakePlayer(string id)
        {
            return GetArrayPlayers().FirstOrDefault(x => x.Name == id);
        }


        private void DoSessionStateUpdated()
        {
            DeskStateUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void ReloadindRoundMessage()
        {
            ReloadRoundMessage?.Invoke(this, EventArgs.Empty);
        }


    }
}
