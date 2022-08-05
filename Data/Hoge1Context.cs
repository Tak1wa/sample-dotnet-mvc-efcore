using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sample_dotnet_mvc_efcore.Data
{
    public class Hoge1Context : DbContext
    {
        public Hoge1Context(DbContextOptions<Hoge1Context> options) : base(options)
        {
        }

        public DbSet<Fuga> Fugas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fuga>().ToTable("Fuga");
        }
    }

    public class Fuga
    {
        public int FugaId { get; set; }

        public string FugaName { get; set; } = string.Empty;
    }
}