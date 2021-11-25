using BlackJack.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<PlayerSessions> PlayerSessions { get; set; }

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
            modelBuilder.Entity<Sessions>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PlayerSessions>(entity =>
            {
                entity.HasKey(x => new { x.SessionId, x.ConectionId });
                entity.HasOne(x => x.Sessions)
                      .WithMany(x => x.PlayerSessions)
                      .HasForeignKey(x => x.SessionId);
                entity.HasIndex(x => x.ConectionId)
                      .IsUnique();
                entity.HasIndex(x => x.Name)
                      .IsUnique(); ;
            });
                

            base.OnModelCreating(modelBuilder);
        }
    }
}
