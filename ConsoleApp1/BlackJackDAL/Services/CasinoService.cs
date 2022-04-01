
using AutoMapper;
using BlackJack.DAL;
using BlackJack.DAL.Context;
using BlackJack.DAL.Models;
using BlackJack.DAL.Repositories;
using BlackJack.Domain.Logic;
using BlackJack.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Services
{
    public class CasinoService : ICasinoService
    {
        private ApplicationContext db;

        public CasinoService(ApplicationContext context)
        {
            db = context;
        }

        public void Create(PlayerDB player)
        {
            db.PlayerDB.Add(player);
        }

        public void Create(DeskDB player)
        {
            throw new NotImplementedException();
        }
    }
}
