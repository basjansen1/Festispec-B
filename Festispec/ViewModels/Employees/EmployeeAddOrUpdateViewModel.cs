using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Address;
using Festispec.ViewModels.Employee;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Employees
{
    public class EmployeeAddOrUpdateViewModel :
        AddressAddOrUpdateViewModelBase<IEmployeeViewModelFactory, EmployeeViewModel, IEmployeeRepository, Domain.Employee>
    {
        public EmployeeAddOrUpdateViewModel(INavigationService navigationService,
            IEmployeeRepositoryFactory repositoryFactory,
            IEmployeeRoleRepositoryFactory employeeRoleRepositoryFactory,
            IEmployeeViewModelFactory employeeViewModelFactory, IGeoRepositoryFactory geoRepositoryFactory)
            : base(navigationService, repositoryFactory, employeeViewModelFactory, geoRepositoryFactory)
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
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.EmployeeAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            // TODO: Validation

            if (EntityViewModel.Manager_Id == -1)
            {
                EntityViewModel.Manager = null;
                EntityViewModel.Manager_Id = null;
            }

            base.Save();
        }
    }
}