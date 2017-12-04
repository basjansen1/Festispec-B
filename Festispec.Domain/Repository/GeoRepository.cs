using System;
using System.Data.Entity.Spatial;
using System.Text.RegularExpressions;
using Festispec.Domain.Repository.Interface;
using GeodanApi;

namespace Festispec.Domain.Repository
{
    public class GeoRepository : IGeoRepository
    {
        private const int CoordinateSystemId = 4326;
        private const string DefaultCountry = "Nederland";

        private readonly IGeodanSearchApi _geodanSearchApi;

        public GeoRepository(IGeodanSearchApi geodanSearchApi)
        {
            _geodanSearchApi = geodanSearchApi;
        }

        /// <summary>
        ///     Finds the address with the given postal code and house number
        /// </summary>
        /// <param name="postalCode"></param>
        /// <param name="houseNumber"></param>
        /// <returns></returns>
        public Address Find(string postalCode, string houseNumber)
        {
            // Generate options based on postal code and house number
            var geodanApiOptions = new GeodanApiOptions(postalCode, houseNumber);

            var data = _geodanSearchApi.Find(geodanApiOptions);

            // Convert geometry data to DbGeography
            var location = DbGeography.PointFromText(data.geom.ToString(), CoordinateSystemId);

            // Convert data to address
            var address = new Address
            {
                City = data.city,
                PostalCode = data.postcode,
                HouseNumber = data.housenumbers,
                Street = data.street,
                Municipality = data.municipality,
                Country = DefaultCountry,
                Lat = location.Latitude,
                Long = location.Longitude,
                Location = location
            };

            return address;
        }

        public void Dispose()
        {
        }
    }
}