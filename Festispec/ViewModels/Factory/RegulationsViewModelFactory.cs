using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Regulations;

namespace Festispec.ViewModels.Factory
{
    public class RegulationsViewModelFactory : IRegulationsViewModelFactory
    {
        private readonly IRegulationsRepositoryFactory _RegulationsRepositoryFactory;

        public RegulationsViewModelFactory(IRegulationsRepositoryFactory RegulationsRepositoryFactory)
        {
            _RegulationsRepositoryFactory = RegulationsRepositoryFactory;
        }

        public RegulationsViewModel CreateViewModel()
        {
            return new RegulationsViewModel(_RegulationsRepositoryFactory);
        }

        public RegulationsViewModel CreateViewModel(Domain.Regulation entity)
        {
            return new RegulationsViewModel(_RegulationsRepositoryFactory, entity);
        }
    }
}
