using CRUD_WEB_API.DTO;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WEB_API
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<MeetUp> MeetUps { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetUp>(entity =>
            {
                entity.ToTable("MeetUp");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasMany(d => d.Meetups)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "Usersmeetup",
                        l => l.HasOne<MeetUp>().WithMany().HasForeignKey("Meetupid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("usersmeetups_meetupid_fkey"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("Userid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("usersmeetups_userid_fkey"),
                        j =>
                        {
                            j.HasKey("Userid", "Meetupid").HasName("users_meetups_pkey");

                            j.ToTable("usersmeetups");

                            j.IndexerProperty<int>("Userid").HasColumnName("userid");

                            j.IndexerProperty<int>("Meetupid").HasColumnName("meetupid");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
