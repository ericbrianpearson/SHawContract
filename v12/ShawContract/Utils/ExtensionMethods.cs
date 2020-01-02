using CMS.Helpers;
using Kentico.Content.Web.Mvc;
using Kentico.Web.Mvc;
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
    }
}