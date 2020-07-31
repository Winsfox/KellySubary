using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using KellySubaru.Common;

namespace KellySubaru.HtmlParsers.KellySubaru
{
    public sealed class KellySubaruVehicleParser : IVehicleParser
    {
        private readonly int _vehicleOrder;

        public KellySubaruVehicleParser(int vehicleOrder)
        {
            _vehicleOrder = vehicleOrder;
        }

        public VehicleInfo GetVehicleInfo(HtmlContent htmlContent)
        {
            var listNode = htmlContent.Document.DocumentNode.SelectSingleNode("//*[@id=\"compareForm\"]/div/div[2]/ul[1]");
            var listItemNode = listNode.SelectSingleNode($"li[{_vehicleOrder}]");

            var vinNode = listItemNode.SelectSingleNode("div[1]/div/div[3]/dl[3]/dd");
            var vinText = vinNode.InnerText;

            var priceNode = listItemNode.SelectSingleNode("div[1]/div/div[2]/ul/li[1]/span/span[2]");
            var priceText = priceNode.InnerText;

            var imageNode = listItemNode.SelectSingleNode("div[1]/div/div[1]/a[1]/img");;
            var imageSrc = imageNode.Attributes["src"].Value;

            var imageUrl = Regex.Match(imageSrc, @"^([^\?]+)").Groups[1].Value;

            var vehicleInfo = new VehicleInfo(vinText, priceText, imageUrl);
            return vehicleInfo;
        }
    }
}