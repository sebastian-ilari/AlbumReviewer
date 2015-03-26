using AlbumReviewerBackend.Models;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AlbumReviewerBackend.Interfaces
{
    [ServiceContract]
    public interface IAlbumReviewerService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetArtists")]
        List<Artist> GetArtists();

        [OperationContract]
        [WebGet(UriTemplate = "GetAlbumsFromArtist/{artistId}")]
        List<AlbumDTO> GetAlbumsFromArtist(string artistId);

        [OperationContract]
        [WebGet(UriTemplate = "GetAlbumById/{albumId}")]
        AlbumDTO GetAlbumById(string albumId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SaveRatingForAlbum/{albumId}/rating/{rating}")]
        bool SaveRatingForAlbum(string albumId, string rating);
    }
}