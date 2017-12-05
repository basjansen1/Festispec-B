using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Regulation;

namespace Festispec.ViewModels.Factory
{
    public class RegulationsViewModelFactory : IRegulationsViewModelFactory
    {
        private readonly IRegulationRepositoryFactory _RegulationsRepositoryFactory;

        public RegulationsViewModelFactory(IRegulationRepositoryFactory RegulationsRepositoryFactory)
        {
            _RegulationsRepositoryFactory = RegulationsRepositoryFactory;
        }

        public RegulationViewModel CreateViewModel()
        {
            return new RegulationViewModel(_RegulationsRepositoryFactory);
        }

        public RegulationViewModel CreateViewModel(Domain.Regulation entity)
        {
            return new RegulationViewModel(_RegulationsRepositoryFactory, entity);
        }
    }
}
