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
            // Clean the given postal code
            postalCode = CleanPostalCode(postalCode);

            // Generate options based on postal code and house number
            var geodanApiOptions = new GeodanApiOptions {PostalCode = postalCode, HouseNumber = houseNumber};
            var data = _geodanSearchApi.Find(geodanApiOptions);

            // Convert geometry data to DbGeography
            var location = DbGeography.PointFromText(data.geom.ToString(), CoordinateSystemId);

            // Convert data to address
            var address = new Address
            {
                City = data.city,
                PostalCode = data.postcode,
                HouseNumber = data.housenumber,
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

        /// <summary>
        ///     Cleans the postal code of spaces and checks for valid dutch postal code
        /// </summary>
        /// <param name="postalCode"></param>
        /// <exception cref="InvalidOperationException">Invalid postalcode format</exception>
        /// <returns></returns>
        private static string CleanPostalCode(string postalCode)
        {
            var cleanedPostalCode = postalCode.Replace(" ", string.Empty);

            var postalCodeRegex = new Regex("^[1-9][0-9]{3}(?!sa|sd|ss)[a-z]{2}$", RegexOptions.IgnoreCase);
            if (!postalCodeRegex.IsMatch(cleanedPostalCode))
                throw new InvalidOperationException($"{postalCode} is not a valid postal code");

            return cleanedPostalCode;
        }
    }
}