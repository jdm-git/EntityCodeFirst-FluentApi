using System.Data.Entity;

namespace Vidzy
{
    public class VidzyContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }    
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Video>()
                .Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Video>()
                .HasRequired(v => v.Genre)
                .WithMany(g => g.Videos)
                .HasForeignKey(v => v.GenreId);

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);


            modelBuilder.Entity<Video>()
                .HasMany(v => v.Tags)
                    .WithMany(t => t.Videos)
                    .Map(m =>
                    {
                        m.ToTable("VideoTags");
                        m.MapLeftKey("VideoId");
                        m.MapRightKey("TagId");
                    });

            modelBuilder.Entity<Tag>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}