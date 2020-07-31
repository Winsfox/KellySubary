using System.IO;
using KellySubaru.Common;
using OpenQA.Selenium.Chrome;

namespace KellySubaru.HtmlProviders
{
    public sealed class SeleniumChromeHtmlProvider : IHtmlProvider
    {
        private readonly string _chromeDriverPath;
        private readonly int _port;
        private readonly string _url;

        public SeleniumChromeHtmlProvider(string chromeDriverPath, int port, string url)
        {
            _chromeDriverPath = chromeDriverPath;
            _port = port;
            _url = url;
        }

        public HtmlContent GetPageContent()
        {
            var directoryPath = Path.GetDirectoryName(_chromeDriverPath);
            var driverFileName = Path.GetFileName(_chromeDriverPath);

            var service = ChromeDriverService.CreateDefaultService(directoryPath, driverFileName);
            service.Port = _port;

            using (var driver = new ChromeDriver(service) { Url = _url })
            {
                var pageContent = driver.PageSource;
                var htmlContent = HtmlContent.Create(pageContent);
                return htmlContent;
            }
        }
    }
}