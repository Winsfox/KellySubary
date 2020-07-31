using KellySubaru.Common;

namespace KellySubaru.HtmlProviders
{
    public interface IHtmlProvider
    {
        HtmlContent GetPageContent();
    }
}