using KellySubaru.Common;
using KellySubaru.HtmlParsers;
using KellySubaru.HtmlProviders;

namespace kellySubaru.DataProviders
{
    public sealed class VehicleDataProvider
    {
        private readonly IHtmlProvider _htmlProvider;
        private readonly IVehicleParser _vehicleParser;

        public VehicleDataProvider(IHtmlProvider htmlProvider, IVehicleParser vehicleParser)
        {
            _htmlProvider = htmlProvider;
            _vehicleParser = vehicleParser;
        }

        public VehicleInfo GetData()
        {
            var pageContent = _htmlProvider.GetPageContent();
            var vehicleInfo = _vehicleParser.GetVehicleInfo(pageContent);
            return vehicleInfo;
        }

        public IHtmlProvider HtmlProvider => _htmlProvider;

        public IVehicleParser VehicleParser => _vehicleParser;
    }
}