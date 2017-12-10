using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using GeodanApi;

namespace Festispec.Domain.Repository.Factory
{
    public class GeoRepositoryFactory : IGeoRepositoryFactory
    {
        private readonly IGeodanSearchApi _geodanSearchApi;

        public GeoRepositoryFactory(IGeodanSearchApi geodanSearchApi)
        {
            _geodanSearchApi = geodanSearchApi;
        }

        public IGeoRepository CreateRepository()
        {
            return new GeoRepository(_geodanSearchApi);
        }
    }
}