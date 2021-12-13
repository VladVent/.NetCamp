
using BlackJack.DAL.Models;
using BlackJack.Domain.Logic;
using BlackJack.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Services
{
    public interface ICasinoService
    {
       // void Create(DeskDB player);

        void Create(PlayerDB player);
        void Delete(int id);
        IEnumerable<PlayerDB> Find(Func<PlayerDB, bool> predicate);
        PlayerDB Get(int id);
        IEnumerable<PlayerDB> GetAll();
       // void Update(DeskDB player);
        void Update(PlayerDB player);
    }
}
