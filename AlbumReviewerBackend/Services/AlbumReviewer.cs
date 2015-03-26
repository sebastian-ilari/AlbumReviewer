using AutoMapper;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Linq;
using AlbumReviewerBackend.Interfaces;
using AlbumReviewerBackend.Models;
using System;

namespace AlbumReviewerBackend.Services
{
    [AspNetCompatibilityRequirements
    (RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AlbumReviewer : IAlbumReviewerService
    {
        private AlbumReviewerEntities albumReviewerEntities;

        public AlbumReviewer()
        {
            if (this.albumReviewerEntities == null)
            {
                this.albumReviewerEntities = new AlbumReviewerEntities();
            }
        }

        public List<Artist> GetArtists()
        {
            return this.albumReviewerEntities.Artists.ToList();
        }

        public List<AlbumDTO> GetAlbumsFromArtist(string artistId)
        {
            try
            {
                int id = Convert.ToInt32(artistId);

                //ATTENTION: AsNoTracking disables EF cache
                IEnumerable<Album> albums = this.albumReviewerEntities.Albums.AsNoTracking()
                                                            .Where(album => album.ArtistId.Equals(id));

                IEnumerable<AlbumDTO> albumDTOs = Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDTO>>(albums);
                Mapper.AssertConfigurationIsValid();

                return this.ComputeRatingFor(albums, albumDTOs).ToList();
            }
            catch
            {
                return new List<AlbumDTO>();
            }
        }

        public AlbumDTO GetAlbumById(string albumId)
        {
            try
            {
                int id = Convert.ToInt32(albumId);

                //ATTENTION: AsNoTracking disables EF cache
                Album album = this.albumReviewerEntities.Albums.AsNoTracking()
                                                        .Where(al => al.AlbumId.Equals(id)).FirstOrDefault();

                AlbumDTO albumDTO = Mapper.Map<Album, AlbumDTO>(album);
                Mapper.AssertConfigurationIsValid();

                return this.ComputeRatingFor(album, albumDTO);
            }
            catch
            {
                return new AlbumDTO();
            }
        }

        public bool SaveRatingForAlbum(string albumId, string rating)
        {
            try
            {
                this.albumReviewerEntities.Ratings.Add(new Rating
                {
                    AlbumId = Convert.ToInt32(albumId),
                    Value = Convert.ToInt32(rating),
                });

                this.albumReviewerEntities.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private IEnumerable<AlbumDTO> ComputeRatingFor(IEnumerable<Album> albums, IEnumerable<AlbumDTO> albumDTOs)
        {
            List<AlbumDTO> result = new List<AlbumDTO>();

            foreach (AlbumDTO albumDTO in albumDTOs)
            {
                Album album = albums.Where(al => al.AlbumId.Equals(albumDTO.AlbumId)).Single();
                result.Add(this.ComputeRatingFor(album, albumDTO));
            }

            return result;
        }

        private AlbumDTO ComputeRatingFor(Album album, AlbumDTO albumDTO)
        {
            int sumRatings;

            albumDTO.AverageRating = 0;
            albumDTO.CantRatings = sumRatings = 0;

            foreach (Rating rating in album.Ratings)
            {
                albumDTO.CantRatings++;
                sumRatings = sumRatings + rating.Value;
            }

            if (albumDTO.CantRatings != 0)
            {
                albumDTO.AverageRating = (decimal)sumRatings / (decimal)albumDTO.CantRatings;
                albumDTO.AverageRating = decimal.Round(albumDTO.AverageRating, 2, MidpointRounding.AwayFromZero);
            }

            return albumDTO;
        }
    }
}