using CMS.Helpers;
using Kentico.Content.Web.Mvc;
using Kentico.Web.Mvc;
using System.Web;
using System.Web.Mvc;

namespace ShawContract.Utils
{
    public static class ExtensionMethods
    {
        public static string KenticoImageUrl(this UrlHelper helper, string path)
        {
            return path != null ? helper.Kentico().ImageUrl(path, SizeConstraint.Empty) : null;
        }

        public static string Localize(this HtmlHelper helper, string key)
        {
            return ResHelper.GetString(key);
        }


        public static string CreateBoardUrl(string boardId, string currentSiteCulture)
        {
            var host = HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority);

            var completeUrl = string.Format(host + "/{0}/ProductBoards/SharedBoard/{1}", currentSiteCulture, boardId);
            return completeUrl;
        }

    }
}