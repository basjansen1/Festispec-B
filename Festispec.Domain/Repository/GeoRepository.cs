using System;
using System.Linq;
using System.Text.RegularExpressions;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class GeoRepository : IGeoRepository
    {
        private readonly IGeodanApi _geodanApi;

        public GeoRepository(IGeodanApi geodanApi)
        {
            _geodanApi = geodanApi;
        }

        public IQueryable<Address> GetByPostalCode(string postalCode)
        {
            postalCode = CleanPostalCode(postalCode);

            return null;
        }

        private string CleanPostalCode(string postalCode)
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

    public interface IGeodanApi
    {
        
    }

    public class GeodanApi
    {
    }
}