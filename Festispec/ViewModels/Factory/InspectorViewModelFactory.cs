using System;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Inspector;

namespace Festispec.ViewModels.Factory
{
    public class InspectorViewModelFactory : IInspectorViewModelFactory
    {
        private readonly IInspectorRepositoryFactory _inspectorRepositoryFactory;
        private readonly IInspectorScheduleViewModelFactory _inspectorScheduleViewModelFactory;
        public InspectorViewModelFactory(IInspectorRepositoryFactory inspectorRepositoryFactory, IInspectorScheduleViewModelFactory inspectorScheduleViewModelFactory)
        {
            _inspectorRepositoryFactory = inspectorRepositoryFactory;
            _inspectorScheduleViewModelFactory = inspectorScheduleViewModelFactory;
        }

        public InspectorViewModel CreateViewModel()
        {
            return new InspectorViewModel(_inspectorRepositoryFactory, _inspectorScheduleViewModelFactory);
        }

        public InspectorViewModel CreateViewModel(Domain.Inspector entity)
        {
            return new InspectorViewModel(_inspectorRepositoryFactory, _inspectorScheduleViewModelFactory, entity);
        }
    }
}