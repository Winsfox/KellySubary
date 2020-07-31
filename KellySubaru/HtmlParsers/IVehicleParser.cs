using KellySubaru.Common;

namespace KellySubaru.HtmlParsers
{
    public interface IVehicleParser
    {
        VehicleInfo GetVehicleInfo(HtmlContent htmlContent);
    }
}