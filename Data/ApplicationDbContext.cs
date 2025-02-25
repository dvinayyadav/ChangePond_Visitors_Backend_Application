using Microsoft.EntityFrameworkCore;
using ChangePond_Visitors_Backend_Application.Entities;
using Host = ChangePond_Visitors_Backend_Application.Entities.Host;

namespace ChangePond_Visitors_Backend_Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Define tables
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<CheckInOutLog> CheckInOutLogs { get; set; }
        public DbSet<SecurityVerification> SecurityVerifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Required for Identity

            // Configure relationships
            modelBuilder.Entity<Visitor>()
                .HasOne(v => v.Host)
                .WithMany(h => h.Visitors)
                .HasForeignKey(v => v.HostID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CheckInOutLog>()
                .HasOne(c => c.Visitor)
                .WithMany(v => v.CheckInOutLogs)
                .HasForeignKey(c => c.VisitorID);
        }
    }
}
