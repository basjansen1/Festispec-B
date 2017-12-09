using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Address;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorAddOrUpdateViewModel :
        AddressAddOrUpdateViewModelBase<IInspectorViewModelFactory, InspectorViewModel, IInspectorRepository, Domain.Inspector>
    {
        public InspectorAddOrUpdateViewModel(INavigationService navigationService,
            IInspectorRepositoryFactory repositoryFactory,
            IInspectorViewModelFactory inspectorViewModelFactory, IEmployeeRepositoryFactory employeeRepositoryFactory, IGeoRepositoryFactory geoRepositoryFactory)
            : base(navigationService, repositoryFactory, inspectorViewModelFactory, geoRepositoryFactory)
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
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.InspectorAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            // TODO: Validation

            base.Save();
        }
    }
}