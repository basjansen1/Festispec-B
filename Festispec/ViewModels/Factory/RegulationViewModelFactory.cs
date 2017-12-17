using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Regulation;

namespace Festispec.ViewModels.Factory
{
    public class RegulationViewModelFactory : IRegulationViewModelFactory
    {
        private readonly IRegulationRepositoryFactory _RegulationRepositoryFactory;

        public RegulationViewModelFactory(IRegulationRepositoryFactory RegulationsRepositoryFactory)
        {
            _RegulationRepositoryFactory = RegulationsRepositoryFactory;
        }

        public RegulationViewModel CreateViewModel()
        {
            return new RegulationViewModel(_RegulationRepositoryFactory);
        }

        public RegulationViewModel CreateViewModel(Domain.Regulation entity)
        {
            return new RegulationViewModel(_RegulationRepositoryFactory, entity);
        }
    }
}
