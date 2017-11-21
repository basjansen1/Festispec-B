using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

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
                Managers = employeeRepository.Get().Where(e => e.Role_Role == "Manager").ToList();
            }
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.InspectorAddOrUpdate.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
            UpdateInspectorFromNavigationParameter();
        }

        public IEnumerable<Domain.Employee> Managers { get; }

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