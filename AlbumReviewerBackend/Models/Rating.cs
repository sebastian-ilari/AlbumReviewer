using System.Runtime.Serialization;

namespace AlbumReviewerBackend.Models
{
    public class Rating
    {
        public int Id { get; set; }
        
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

        public int Value { get; set; }
    }
}