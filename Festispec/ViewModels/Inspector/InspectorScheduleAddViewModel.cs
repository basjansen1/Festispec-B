using System.ComponentModel;
using System.Windows;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorScheduleAddViewModel :
        InspectorScheduleAddOrUpdateViewModel
    {
        public InspectorScheduleAddViewModel(INavigationService navigationService,
            IInspectorScheduleRepositoryFactory repositoryFactory, IInspectorScheduleViewModelFactory viewModelFactory)
            : base(navigationService, repositoryFactory, viewModelFactory)
        {
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.InspectorScheduleAdd) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {

            //validation for checking if dates are entered correctly
            if (EntityViewModel.Entity.NotAvailableFrom > EntityViewModel.Entity.NotAvailableTo)
            {
                MessageBox.Show("De datums zijn niet correct ingevoerd.");
            }
            else
            {
                InspectorViewModel.Schedule.Add(EntityViewModel);

                GoBack();
            }
        }
    }
}