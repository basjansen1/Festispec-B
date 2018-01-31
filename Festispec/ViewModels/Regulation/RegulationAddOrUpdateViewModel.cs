using System.ComponentModel;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Regulation
{
    public class RegulationAddOrUpdateViewModel : 
        AddOrUpdateViewModelBase<IRegulationViewModelFactory, RegulationViewModel, IRegulationRepository, Domain.Regulation>
    {
        public RegulationAddOrUpdateViewModel(INavigationService navigationService,
            IRegulationRepositoryFactory repositoryFactory,
            IRegulationViewModelFactory regulationsViewModelFactory)
            : base(navigationService, repositoryFactory, regulationsViewModelFactory)
        {
           
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.RegulationAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            // TODO: Validation

            base.Save();
        }
    }
}
