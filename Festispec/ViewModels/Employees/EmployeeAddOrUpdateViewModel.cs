using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Employee;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Employees
{
    public class EmployeeAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<IEmployeeViewModelFactory, EmployeeViewModel, IEmployeeRepository, Domain.Employee>
    {
        public EmployeeAddOrUpdateViewModel(INavigationService navigationService,
            IEmployeeRepositoryFactory repositoryFactory,
            IEmployeeRoleRepositoryFactory employeeRoleRepositoryFactory,
            IEmployeeViewModelFactory employeeViewModelFactory)
            : base(navigationService, repositoryFactory, employeeViewModelFactory)
        {
            using (var employeeRepository = repositoryFactory.CreateRepository())
            {
                Managers = new[] {new Domain.Employee {Id = -1}}.Concat(employeeRepository.Get()
                    .Where(e => e.Role_Role == "Manager" && e.Id != EntityViewModel.Id).ToList());
            }
            using (var employeeRoleRepository = employeeRoleRepositoryFactory.CreateRepository())
            {
                Roles = employeeRoleRepository.Get().Where(e => e.Role != "Inspecteur").ToList();
            }
        }

        public IEnumerable<Domain.Employee> Managers { get; }
        public IEnumerable<EmployeeRole> Roles { get; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentRoute != Routes.Routes.EmployeeAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            if (EntityViewModel.UpdatedEntity.Manager_Id == -1)
            {
                EntityViewModel.UpdatedEntity.Manager = null;
                EntityViewModel.UpdatedEntity.Manager_Id = null;
            }

            // TODO: Validation
            var saved = EntityViewModel.Save();

            if(saved) NavigationService.GoBack(EntityViewModel);
        }
    }
}