using EfficyDemo.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace EfficyDemo.Dal
{
    public class EfficyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Counter> Counters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EfficyDemo.Db;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd(); // This indicates that the Id is an identity column

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.TeamId).IsRequired();

                entity.HasOne(e => e.Team)
                    .WithMany(t => t.Employees)
                    .HasForeignKey(e => e.TeamId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd(); // This indicates that the Id is an identity column

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd(); // This indicates that the Id is an identity column

                entity.Property(e => e.Value).IsRequired();
                entity.Property(e => e.EmployeeId).IsRequired();

                entity.HasOne(e => e.Employee)
                    .WithMany(e => e.Counters)
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
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
