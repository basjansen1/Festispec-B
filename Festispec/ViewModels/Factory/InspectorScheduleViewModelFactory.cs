using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Inspector;

namespace Festispec.ViewModels.Factory
{
    public class InspectorScheduleViewModelFactory : IInspectorScheduleViewModelFactory
    {
        private readonly IInspectorScheduleRepositoryFactory _inspectorScheduleRepositoryFactory;
        public InspectorScheduleViewModelFactory(IInspectorScheduleRepositoryFactory inspectorScheduleRepositoryFactory)
        {
            _inspectorScheduleRepositoryFactory = inspectorScheduleRepositoryFactory;
        }

        public InspectorScheduleViewModel CreateViewModel()
        {
            return new InspectorScheduleViewModel(_inspectorScheduleRepositoryFactory);
        }

        public InspectorScheduleViewModel CreateViewModel(Domain.Schedule entity)
        {
            return new InspectorScheduleViewModel(_inspectorScheduleRepositoryFactory, entity);
        }
    }
}