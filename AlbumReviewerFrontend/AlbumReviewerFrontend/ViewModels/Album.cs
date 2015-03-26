namespace AlbumReviewerFrontend.ViewModels
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string Genre { get; set; }

        public string ArtistId { get; set; }

        public string ArtistName { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int CantRatings { get; set; }
        
        public decimal AverageRating { get; set; }
    }
}