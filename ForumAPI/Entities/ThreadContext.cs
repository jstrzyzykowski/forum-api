using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Entities
{
    public class ThreadContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=ThreadDb;Trusted_Connection=True;";

        public DbSet<Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thread>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.Thread);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
