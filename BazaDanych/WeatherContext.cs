using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BazaDanych
{
    internal class WeatherContext:DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherEntry> WeatherEntries { get; set; }

        public WeatherContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherEntry>().HasOne(w => w.City).WithMany(c => c.WeatherEntries).HasForeignKey(w => w.CityId)
                .OnDelete(DeleteBehavior.Cascade);
            //ustawienie usuwania kaskadowego, razem z miastem usuwaja sie wszystkie wpisy
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@" Data Source = Weather .db");
        }
    }
}
