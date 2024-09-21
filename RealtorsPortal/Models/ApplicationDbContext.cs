using Microsoft.EntityFrameworkCore;

namespace RealtorsPortal.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions option):base(option)
        {
            
        }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Contactus> ContactUs { get; set; }
        public DbSet<Team> OurTeam { get; set; }
        public DbSet<PrivateSeller> PrivateSellers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Agent) 
                .WithMany(a => a.Properties) 
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);
           
            modelBuilder.Entity<Property>()
                .HasOne(p => p.PrivateSeller)
                .WithMany(ps => ps.Properties)
                .HasForeignKey(p => p.PrivateSellerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Property>()
                .Property(p => p.Name)
                .HasMaxLength(100);
        }
    }
}
