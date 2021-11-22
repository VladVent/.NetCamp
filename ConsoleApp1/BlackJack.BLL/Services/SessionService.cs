using BlackJack.DAL.Models;
using BlackJack.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.Services
{
    public class SessionService
    {
        private IGenericRepository<Sessions> _sessionRepository;
        private IGenericRepository<PlayerSessions> _playerSessionRepository;

        public SessionService(IGenericRepository<Sessions> sessionRepository, IGenericRepository<PlayerSessions> playerSessionRepository)
        {
            _sessionRepository = sessionRepository;
            _playerSessionRepository = playerSessionRepository;
        }


    }
}
