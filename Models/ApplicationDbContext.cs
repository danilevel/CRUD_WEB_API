using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CRUD_WEB_API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MeetUp> MeetUps { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetUp>(entity =>
            {
                entity.ToTable("MeetUp");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
            });
        }
    }
}