
namespace Employees.Data
{
   
    using Microsoft.EntityFrameworkCore;
    using Employees.Models;
    public class EmployeesContext : DbContext
    {
        public EmployeesContext() { }

        public EmployeesContext(DbContextOptions options)
            : base(options) { }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName)
                    .IsRequired(true)
                    .HasMaxLength(30);
                entity.Property(e => e.LastName)
                    .IsRequired(true)
                    .HasMaxLength(30);
                entity.Property(e => e.Address)
                    .IsRequired(false)
                    .HasMaxLength(250);
            });
        }
    }
}
