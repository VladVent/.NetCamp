using BlackJack.DAL.Models;
using BlackJack.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.Services
{
    public interface ISessionService
    {
        void CleanEmptySessions();
        void CleanSessions();
        int FindSession(string userId, string userName);
        int GetPlayerSesion(string userId);
        TableSession GetSessionById(int sessionId);
        void PlayerTakeCard(TableSession tableSession, string identity);
        void PlayerWouldStop(TableSession tableSession, string identity);
        int RemoveUserFromSession(string userId);
        void RestartTable(TableSession tableSession, string identity);
        void UpdateSession(TableSession tableSession);
    }
}
