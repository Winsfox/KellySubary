using AngleSharp.Dom;
using HtmlAgilityPack;

namespace KellySubaru.Common
{
    public sealed class HtmlContent
    {
        private readonly HtmlDocument _document;

        private HtmlContent(HtmlDocument document)
        {
            _document = document;
        }

        public HtmlDocument Document => _document;

        public static HtmlContent Create(string content)
        {
            var document = new HtmlDocument();
            document.LoadHtml(content);

            var htmlContent = new HtmlContent(document);

            return htmlContent;
        }
    }
}