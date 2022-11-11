using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Designations> EmployeeDesignation { get; set; }
        public DbSet<PaymentRule> PaymentRules { get; set; }
        public DbSet<RequestLeave> RequestLeaves { get; set; }
        public DbSet<WorkingHour> WorkingHour { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Register> registers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}

