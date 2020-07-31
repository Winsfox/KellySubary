using System;
using kellySubaru.Configuration;
using kellySubaru.DataProviders;
using KellySubaru.HtmlParsers.KellySubaru;
using KellySubaru.HtmlProviders;
using Microsoft.Extensions.Configuration;

namespace kellySubaru
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .Build();

            var chromeDriverConfig = new ChromeDriverConfig();
            configuration.Bind("ChromeDriver", chromeDriverConfig);

            var kellySubaruUrl = configuration.GetValue<string>("KellySubaru:Url");
            var kellySubaruVehicleOrder = configuration.GetValue<int>("KellySubaru:VehicleOrder");

            var htmlProvider = new SeleniumChromeHtmlProvider(
                chromeDriverConfig.Path,
                chromeDriverConfig.Port,
                kellySubaruUrl);
            var parser = new KellySubaruVehicleParser(kellySubaruVehicleOrder);
            var vehicleDataProvider = new VehicleDataProvider(htmlProvider, parser);
            var vehicleInfo = vehicleDataProvider.GetData();

            Console.WriteLine($"Vin: {vehicleInfo.Vin}, Price: {vehicleInfo.Price}, PhotoUrl: {vehicleInfo.PhotoUrl}.");
        }
    }
}