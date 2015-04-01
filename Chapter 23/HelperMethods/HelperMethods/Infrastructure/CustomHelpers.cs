namespace HelperMethods.Infrastructure
{
    using System.Web.Mvc;

    public static class CustomHelpers
    {
        public static MvcHtmlString ListArrayItems(this HtmlHelper html, string[] list)
        {
            var tag = new TagBuilder("ul");
            foreach (var str in list)
            {
                var itemTag = new TagBuilder("li");
                itemTag.SetInnerText(str);
                tag.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }

        //public static MvcHtmlString DisplayMessage(this HtmlHelper html, string message)
        //{
        //    var result = string.Format("This is the message : <p>{0}</p>", message);
        //    return new MvcHtmlString(result);
        //}

        public static MvcHtmlString DisplayMessage(this HtmlHelper html, string message)
        {
            var result = string.Format("This is the message : <p>{0}</p>", html.Encode(message));
            return new MvcHtmlString(result);
        }
    }
}