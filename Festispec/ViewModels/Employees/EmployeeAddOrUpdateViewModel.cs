using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

namespace Festispec.ViewModels.Employee
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
                _managers = employeeRepository.Get().Where(e => e.Role_Role == "Manager").ToList();
            }
            using (var employeeRoleRepository = employeeRoleRepositoryFactory.CreateRepository())
            {
                Roles = employeeRoleRepository.Get().Where(e => e.Role != "Manager").ToList();
            }
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.EmployeeAddOrUpdate.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
            UpdateEmployeeFromNavigationParameter();
        }

        private readonly IEnumerable<Domain.Employee> _managers;
        public IEnumerable<Domain.Employee> Managers { get { return _managers.Where(m => m.Id != EntityViewModel.Id).ToList(); } }
        public IEnumerable<Domain.EmployeeRole> Roles { get;}

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