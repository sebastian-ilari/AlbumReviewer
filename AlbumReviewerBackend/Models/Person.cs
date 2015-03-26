using System.Runtime.Serialization;

namespace AlbumReviewerBackend.Models
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string Name;
        [DataMember]
        public string Age;
    }
}