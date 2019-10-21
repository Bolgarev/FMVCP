using System.Web.Mvc;

namespace FMVCP.Helpers
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper html, string src, string alt)
        {
            var img = new TagBuilder("img");
            img.MergeAttribute(src, "src");
            img.MergeAttribute(alt, "alt");

            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }
    }
}