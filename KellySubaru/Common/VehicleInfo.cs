namespace KellySubaru.Common
{
    public sealed class VehicleInfo
    {
        private readonly string _vin;
        private readonly string _price;
        private readonly string _photoUrl;

        public VehicleInfo(string vin, string price, string photoUrl)
        {
            _vin = vin;
            _price = price;
            _photoUrl = photoUrl;
        }

        public string Vin => _vin;

        public string Price => _price;

        public string PhotoUrl => _photoUrl;
    }
}