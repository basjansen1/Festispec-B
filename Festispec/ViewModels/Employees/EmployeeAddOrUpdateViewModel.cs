using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Employee;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Employees
{
    public class EmployeeAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<IEmployeeViewModelFactory, EmployeeViewModel, Domain.Employee>
    {
        public EmployeeAddOrUpdateViewModel(INavigationService navigationService,
            IEmployeeRepositoryFactory repositoryFactory,
            IEmployeeRoleRepositoryFactory employeeRoleRepositoryFactory,
            IEmployeeViewModelFactory employeeViewModelFactory)
            : base(navigationService, repositoryFactory, employeeViewModelFactory)
        {
            using (var employeeRepository = repositoryFactory.CreateRepository())
            {
                Managers = employeeRepository.Get().Where(e => e.Role_Role == "Manager" && e.Id != EntityViewModel.Id).ToList();
            }
            using (var employeeRoleRepository = employeeRoleRepositoryFactory.CreateRepository())
            {
                Roles = employeeRoleRepository.Get().Where(e => e.Role != "Manager").ToList();
            }

            ClearManagerCommand = new RelayCommand(() =>
            {
                EntityViewModel.UpdatedEntity.Manager = null;
                EntityViewModel.UpdatedEntity.Manager_Id = null;
                RaisePropertyChanged(nameof(EntityViewModel.UpdatedEntity.Manager));
                RaisePropertyChanged(nameof(EntityViewModel.UpdatedEntity.Manager_Id));
            });
        }

        public ICommand ClearManagerCommand { get; }
        public IEnumerable<Domain.Employee> Managers { get; }
        public IEnumerable<EmployeeRole> Roles { get; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.EmployeeAddOrUpdate.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            // TODO: Validation
            EntityViewModel.Save();

            NavigationService.GoBack(EntityViewModel);
        }
    }
}