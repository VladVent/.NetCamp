using BlackJack.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PlayerDB> PlayerDB { get; set; }
       // public DbSet<SessionDB> SessionDB { get; set; }
       // public DbSet<DeskDB> DeskDB { get; set; }
       //public DbSet<CasinoDB> CasinoDB { get; set; }

       // public DbSet<CardSDB> CardSDBs { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=BlackJack;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CasinoDB>()
            //   .HasKey(x => x.DeskId);

            //modelBuilder.Entity<SessionDB>()
            //  .HasKey(x => x.SessionId);

            //modelBuilder.Entity<DeskDB>()
            //  .HasKey(x => x.DeskId);
            //modelBuilder.Entity<CardSDB>()
            //    .HasKey(x => x.IdCard);

            modelBuilder.Entity<PlayerDB>()
                .HasKey(x => x.PlayerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
