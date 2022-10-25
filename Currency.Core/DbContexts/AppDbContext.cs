using Currency.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Core.DbContexts
{
    public class AppDbContext : DbContext 
    {
        private const string ConnectionString = 
            "Server=(localdb)\\mssqllocaldb;Database=CurrencyDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public virtual DbSet<CurrencyEntity> Currencies { get; set; }
    }
}
