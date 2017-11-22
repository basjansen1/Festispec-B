using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<IInspectorViewModelFactory, InspectorViewModel, Domain.Inspector>
    {
        public InspectorAddOrUpdateViewModel(INavigationService navigationService,
            IInspectorRepositoryFactory repositoryFactory,
            IInspectorViewModelFactory inspectorViewModelFactory, IEmployeeRepositoryFactory employeeRepositoryFactory)
            : base(navigationService, repositoryFactory, inspectorViewModelFactory)
        {
            using (var employeeRepository = employeeRepositoryFactory.CreateRepository())
            {
                Managers = new[] {new Domain.Employee {Id = -1}}.Concat(employeeRepository.Get()
                    .Where(e => e.Role_Role == "Manager").ToList());
            }
        }

        public IEnumerable<Domain.Employee> Managers { get; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.InspectorAddOrUpdate.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
            UpdateInspectorFromNavigationParameter();
        }

        private void UpdateInspectorFromNavigationParameter()
        {
        }

        public override void Save()
        {
            // TODO: Validation
            EntityViewModel.Save();

            //            using (var InspectorQuestionRepository = _InspectorQuestionRepositoryFactory.CreateRepository())
            //            {
            //                foreach (var InspectorQuestion in EntityViewModel.UpdatedEntity.Questions)
            //                    InspectorQuestionRepository.AddOrUpdate(InspectorQuestion);
            //            }

            NavigationService.GoBack(EntityViewModel);
        }
    }
}