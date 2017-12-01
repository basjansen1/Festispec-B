using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain;
using Festispec.Domain.Repository;
using Festispec.NavigationService;
using Festispec.ViewModels.Employees;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels
{
    public class MainViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            // TODO: Temp remove
            using (var inspectionRepository = new InspectionRepository(new FestispecContainer()))
            {
                _inspection = inspectionRepository.Get().FirstOrDefault();
            }

            RegisterCommands();
        }

        public ICommand NavigateToTemplateListCommand { get; private set; }
        public ICommand NavigateToEmployeeListCommand { get; private set; }

        public ICommand NavigateToInspectorListCommand { get; private set; }

        public ICommand NavigateToInspectionPlanningCommand { get; private set; }

        private Inspection _inspection;

        public void RegisterCommands()
        {
            NavigateToTemplateListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.TemplateList), () => _navigationService.HasAccess(Routes.Routes.TemplateList));
            NavigateToEmployeeListCommand = 
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.EmployeeList), () => _navigationService.HasAccess(Routes.Routes.EmployeeList));
            NavigateToInspectorListCommand = 
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.InspectorList), () => _navigationService.HasAccess(Routes.Routes.InspectorList));


            // TODO: Temp remove
            NavigateToInspectionPlanningCommand = new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.PlanningList, _inspection.Id), () => _navigationService.HasAccess(Routes.Routes.PlanningList));
        }
    }
}