using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AlbumReviewerBackend.Models
{
    public class AlbumReviewerEntities : DbContext
    {
        public AlbumReviewerEntities() : base("name=DefaultConnection")
        {
    
        }

        public DbSet<Album> Albums { get; set; }
        
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}