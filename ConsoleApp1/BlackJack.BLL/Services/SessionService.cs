using BlackJack.DAL.Models;
using BlackJack.DAL.Repositories;
using BlackJack.Types;
using Newtonsoft.Json;
using BlackJack.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BlackJack.BLL.Services
{
    public class SessionService : ISessionService
    {
        private IGenericRepository<Sessions> _sessionRepository;
        private IGenericRepository<PlayerSessions> _playerSessionRepository;
        private IMapper _mapper;

        public SessionService(
            IGenericRepository<Sessions> sessionRepository,
            IGenericRepository<PlayerSessions> playerSessionRepository,
            IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _playerSessionRepository = playerSessionRepository;
            _mapper = mapper;
        }

        public int FindSession(string userId, string userName)
        {
            var sessions = _sessionRepository
                .GetWithInclude(x => x.PlayerSessions)
                .Where(x => x.PlayerSessions.Count < 2)
                .FirstOrDefault();

            if (sessions == null)
            {
                var tableSession = new TableSession(Environment.TickCount);
                tableSession.Join(userName, userId);
                sessions = _sessionRepository.Create(_mapper.Map<Sessions>(tableSession));
            }
            else
            {
                var tableSession = _mapper.Map<TableSession>(sessions);
                tableSession.Join(userName, userId);
                UpdateSession(tableSession);
            }

            return sessions.Id;
        }

        public TableSession GetSessionById(int sessionId)
        {
            var session = _sessionRepository.GetWithInclude(x => x.Id == sessionId, x => x.PlayerSessions).FirstOrDefault();
            return _mapper.Map<TableSession>(session);
        }
        public void UpdateSession(TableSession tableSession)
        {
            var session = _mapper.Map<Sessions>(tableSession);
            _sessionRepository.Update(session);
        }

        public void CleanEmptySessions()
        {
            var sessions = _sessionRepository.GetWithInclude(x => x.PlayerSessions).Where(x => x.PlayerSessions.Count == 0);
            _sessionRepository.RemoveRange(sessions);
        }
        public void CleanSessions()
        {
            var sessions = _sessionRepository.Get();
            _sessionRepository.RemoveRange(sessions);
        }

        public int GetPlayerSesion(string userId)
        {
            var sessionId = _playerSessionRepository.Get(x => x.ConectionId == userId).FirstOrDefault()?.SessionId;
            return sessionId.GetValueOrDefault();
        }
        public int RemoveUserFromSession(string userId)
        {
            var ps = _playerSessionRepository.Get(x => x.ConectionId == userId).FirstOrDefault();
            _playerSessionRepository.Remove(ps);

            return ps.SessionId;
        }

        public void PlayerTakeCard(TableSession tableSession, string identity)
        {
            PlayerState? playerName = TakeSessions(tableSession, identity);
            tableSession.PlayerTakeCard(playerName);
            SessionUpdate(tableSession);

        }

       

        public void PlayerWouldStop(TableSession tableSession, string identity)
        {
            PlayerState? playerName = TakeSessions(tableSession, identity);
            tableSession.PlayerWouldLikeStop(playerName);
            SessionUpdate(tableSession);
        }

        public void RestartTable(TableSession tableSession, string identity)
        {
            tableSession.RestartSession();

            var session = _mapper.Map<Sessions>(tableSession);
            _sessionRepository.Update(session);
        }

        private void SessionUpdate(TableSession tableSession)
        {
            var session = _mapper.Map<Sessions>(tableSession);
            _sessionRepository.Update(session);
        }

        private static PlayerState? TakeSessions(TableSession tableSession, string identity)
        {
            return tableSession.players.Where(x => x.Name == identity).FirstOrDefault();
        }
    }
}
