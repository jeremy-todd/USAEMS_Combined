using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using USAEMS.Core.Models;

namespace USAEMS.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=../USAEMS.Infrastructure/usaems.db");
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}