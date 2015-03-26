using AlbumReviewerFrontend.Utils;
using AlbumReviewerFrontend.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace AlbumReviewerFrontend.Controllers
{
    public class HomeController : Controller
    {
        private RestClient restClient;

        public HomeController()
        {
            this.restClient = new RestClient("http://localhost:8080/AlbumReviewer/");
        }

        public ActionResult Index()
        {
            IEnumerable<Artist> artists = this.GetArtists();
            return View(artists);
        }

        private IEnumerable<Artist> GetArtists()
        {
            this.restClient.EndPoint = string.Concat(this.restClient.EndPoint, "GetArtists");
            string json = this.restClient.MakeRequest();
            return (IEnumerable<Artist>)JsonConvert.DeserializeObject(json, typeof(IEnumerable<Artist>));
        }
        
        public PartialViewResult GetAlbumsFromArtist(int artistId)
        {
            this.restClient.EndPoint = string.Concat(this.restClient.EndPoint, "GetAlbumsFromArtist/", artistId);
            string json = this.restClient.MakeRequest();
            IEnumerable<Album> albums = (IEnumerable<Album>)JsonConvert.DeserializeObject(json, typeof(IEnumerable<Album>));

            return PartialView("_Albums", albums);
        }
    }
}