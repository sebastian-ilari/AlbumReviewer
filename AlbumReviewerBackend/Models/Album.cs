using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumReviewerBackend.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        public int GenreId { get; set; }

        public int ArtistId { get; set; }

        [StringLength(160)]
        public string Title { get; set; }

        public decimal Price { get; set; }

        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }
            
        public virtual Genre Genre { get; set; }
            
        public virtual Artist Artist { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}