using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AlbumReviewerBackend.Models
{
    [DataContract]
    public class AlbumDTO
    {
        [DataMember]
        public int AlbumId { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public string ArtistId { get; set; }

        [DataMember]
        public string ArtistName { get; set; }

        [StringLength(160)]
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int CantRatings { get; set; }
        
        [DataMember]
        public decimal AverageRating { get; set; }
    }
}