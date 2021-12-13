
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

        //public void Create(DeskDB desk)
        //{
        //    db.DeskDB.Add(desk);
        //}

        public void Delete(int id)
        {
            PlayerDB player = db.PlayerDB.Find(id);

            if (player != null)
                db.PlayerDB.Remove(player);
        }

        public IEnumerable<PlayerDB> Find(Func<PlayerDB, bool> predicate)
        {
            return db.PlayerDB.Where(predicate).ToList();
        }

        public PlayerDB Get(int id) => db.PlayerDB.Find(id);

        public IEnumerable<PlayerDB> GetAll() => db.PlayerDB;

        public void Update(DeskDB desk)
        {
            db.Entry(desk).State = EntityState.Modified;
        }

        public void Update(PlayerDB player)
        {
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
