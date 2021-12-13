
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
        void Create(DeskDB player);
        void Create(PlayerDB player);
    }
}
