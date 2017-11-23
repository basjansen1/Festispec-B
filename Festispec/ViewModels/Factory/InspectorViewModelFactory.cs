using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Inspector;

namespace Festispec.ViewModels.Factory
{
    public class InspectorViewModelFactory : IInspectorViewModelFactory
    {
        private readonly IInspectorRepositoryFactory _InspectorRepositoryFactory;
        public InspectorViewModelFactory(IInspectorRepositoryFactory InspectorRepositoryFactory)
        {
            _InspectorRepositoryFactory = InspectorRepositoryFactory;
        }

        public InspectorViewModel CreateViewModel()
        {
            return new InspectorViewModel(_InspectorRepositoryFactory);
        }

        public InspectorViewModel CreateViewModel(Domain.Inspector entity)
        {
            return new InspectorViewModel(_InspectorRepositoryFactory, entity);
        }
    }
}