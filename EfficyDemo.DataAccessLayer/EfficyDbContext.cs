using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfficyDemo.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EfficyDemo.DataAccessLayer
{
    public class EfficyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Counter> Counters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EfficyDemo.Database;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Team)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TeamId);

            modelBuilder.Entity<Counter>()
                .HasOne(c => c.Employee)
                .WithMany(e => e.Counters)
                .HasForeignKey(c => c.EmployeeId);
        }

        public EfficyDbContext(DbContextOptions<EfficyDbContext> options)
            : base(options)
        {
        }

        public EfficyDbContext(): base()
        {

        }
    }
}
