
using BlackJack.Domain.Logic;
using BlackJack.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.Services
{
    public interface ICasinoService
    {
        void CleanEmptySessions();
        void CleanSessions();
        Desk GetOrCreateSession(int userId, string userName);
        Desk GetSessionById(int sessionId);
    }
}
