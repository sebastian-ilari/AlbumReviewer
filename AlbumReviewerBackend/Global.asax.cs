using AlbumReviewerBackend.Models;
using AlbumReviewerBackend.Services;
using AutoMapper;
using System;
using System.ServiceModel.Activation;
using System.Web.Routing;

namespace AlbumReviewerBackend
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("PersonService", new WebServiceHostFactory(), typeof(PersonService)));
            RouteTable.Routes.Add(new ServiceRoute("AlbumReviewer", new WebServiceHostFactory(), typeof(AlbumReviewer)));

            Mapper.CreateMap<Album, AlbumDTO>()
                        .ForMember(dest => dest.Genre, alb => alb.MapFrom(src => src.Genre.Name));
            Mapper.CreateMap<Album, AlbumDTO>()
                        .ForMember(dest => dest.ArtistName, alb => alb.MapFrom(src => src.Artist.Name));
            Mapper.CreateMap<Album, AlbumDTO>()
                        .ForMember(dest => dest.CantRatings, alb => alb.Ignore());
            Mapper.CreateMap<Album, AlbumDTO>()
                        .ForMember(dest => dest.AverageRating, alb => alb.Ignore());
        }
    }
}