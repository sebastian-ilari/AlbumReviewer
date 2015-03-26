using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AlbumReviewerBackend.Models
{
    [DataContract]
    public class Artist
    {
        [DataMember]
        public int ArtistId { get; set; }
        
        [DataMember]
        [StringLength(1024)]
        public string Name { get; set; }
    }
}