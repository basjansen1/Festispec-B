using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.Command;

namespace Festispec.ViewModels.Employee
{
    public class EmployeeAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<IEmployeeViewModelFactory, EmployeeViewModel, Domain.Employee>
    {

        public EmployeeAddOrUpdateViewModel(INavigationService navigationService,
            IEmployeeRepositoryFactory repositoryFactory,
            IEmployeeViewModelFactory EmployeeViewModelFactory)
            : base(navigationService, repositoryFactory, EmployeeViewModelFactory)
        {
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.EmployeeAddOrUpdate.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
            UpdateEmployeeFromNavigationParameter();
        }

        private void UpdateEmployeeFromNavigationParameter()
        {
            
        }

        public override void Save()
        {
            // TODO: Validation
            EntityViewModel.Save();

            //            using (var EmployeeQuestionRepository = _EmployeeQuestionRepositoryFactory.CreateRepository())
            //            {
            //                foreach (var EmployeeQuestion in EntityViewModel.UpdatedEntity.Questions)
            //                    EmployeeQuestionRepository.AddOrUpdate(EmployeeQuestion);
            //            }

            NavigationService.GoBack(EntityViewModel);
        }
    }
}