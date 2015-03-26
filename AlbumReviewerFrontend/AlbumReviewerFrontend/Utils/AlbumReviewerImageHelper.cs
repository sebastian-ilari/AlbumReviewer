using AlbumReviewerFrontend.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;

namespace AlbumReviewerFrontend.Utils
{
    /// <summary>
    /// Custom ImageHelper
    /// </summary>
    public static class AlbumReviewerImageHelper
    {
        public static HtmlString AlbumReviewerImage(this HtmlHelper helper, Album album, string position, string url)
        {
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            TagBuilder builder = new TagBuilder("img");

            builder.Attributes["id"] = position;
            builder.Attributes["data-position"] = position;
            builder.Attributes["data-album-id"] = album.AlbumId.ToString();

            url = (Convert.ToDecimal(position) <= Math.Round(album.AverageRating)) ? url.Replace("off", "rated") : url;
            
            builder.MergeAttribute("src", urlHelper.Content(url));

            MvcHtmlString tag = new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));

            return tag;
        }
    }
}