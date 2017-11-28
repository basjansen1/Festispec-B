using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class GeoRepository : IGeoRepository
    {
        private readonly IGeodanSearchApi _geodanSearchApi;

        public GeoRepository(IGeodanSearchApi geodanSearchApi)
        {
            _geodanSearchApi = geodanSearchApi;
        }

        public IQueryable<Address> Get(string postalCode, string houseNumber)
        {
            postalCode = CleanPostalCode(postalCode);
            
            var data = _geodanSearchApi.Get();

            return null;
        }

        private static string CleanPostalCode(string postalCode)
        {
            var cleanedPostalCode = postalCode.Replace(" ", string.Empty);

            var postalCodeRegex = new Regex("^[1-9][0-9]{3}(?!sa|sd|ss)[a-z]{2}$", RegexOptions.IgnoreCase);
            if(!postalCodeRegex.IsMatch(cleanedPostalCode))
                throw new InvalidOperationException($"${postalCode} is not a valid postal code");

            return cleanedPostalCode;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    
    public class GeodanApiOptions
    {
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }
    }

    public interface IGeodanSearchApi
    {
        ICollection<object> Get(GeodanApiOptions options);
    }

    public class GeodanSearchApi : IGeodanSearchApi
    {
        private readonly string _apiUrl;
        private readonly string _apiKey;

        public GeodanSearchApi()
        {
            _apiUrl = "https://services.geodan.nl/geosearch/free";
            _apiKey = "19aca9fb-6705-11e7-a442-005056805b87";
        }

        public ICollection<object> Get(GeodanApiOptions options)
        {
            throw new NotImplementedException();
        }
    }
}