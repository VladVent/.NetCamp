
using AutoMapper;
using BlackJack.DAL;
using BlackJack.DAL.Repositories;
using BlackJack.Domain.Logic;
using BlackJack.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.Services
{
    public class CasinoService : ICasinoService
    {
        private IGenericRepository<Desk> deskRepository;
        private IMapper _mapper;

        public CasinoService(
            IGenericRepository<Desk> sessionRepository,
            IMapper mapper)
        {
            deskRepository = sessionRepository;
            _mapper = mapper;
        }

        public Desk GetOrCreateSession(int userId, string userName)
        {
            //var sessions = deskRepository
            //    .GetWithInclude(x => x.tableSession)
            //    .FirstOrDefault();

            var desk = deskRepository
                .Get(x => x.IsDeskPlayable())
                .FirstOrDefault();
            if (desk == null)
            {
                desk = new Desk();
               Casino.allAvailableTables.Add(desk);
            }
           desk.JoinPlayer(userId, userName);
           return desk;
        }

        public Desk GetSessionById(int sessionId)
        {
            var session = deskRepository.GetWithInclude(x => x.deskId == sessionId, x => x.tableSession).FirstOrDefault();
            return _mapper.Map<Desk>(session);
        }
        public void CleanEmptySessions()
        {
            var sessions = deskRepository.GetWithInclude(x => x.deskId).Where(x => x.tableSession.players.Count == 0);
            deskRepository.RemoveRange(sessions);
        }
        public void CleanSessions()
        {
            var sessions = deskRepository.Get();
            deskRepository.RemoveRange(sessions);
        }
    }
}
