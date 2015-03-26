using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumReviewerBackend.Models
{
    public partial class Genre
    {
        public int GenreId { get; set; }

        [StringLength(1024)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }
        
        public List<Album> Albums { get; set; }
    }
}