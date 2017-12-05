using System.ComponentModel;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Regulation
{
    public class RegulationAddOrUpdateViewModel : 
        AddOrUpdateViewModelBase<IRegulationsViewModelFactory, RegulationViewModel, IRegulationRepository, Domain.Regulation>
    {
        public RegulationAddOrUpdateViewModel(INavigationService navigationService,
            IRegulationRepositoryFactory repositoryFactory,
            IRegulationsViewModelFactory regulationsViewModelFactory)
            : base(navigationService, repositoryFactory, regulationsViewModelFactory)
        {
           
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.RegulationsAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            // TODO: Validation
            var saved = EntityViewModel.Save();

            if (saved) NavigationService.GoBack(EntityViewModel);
        }
    }
}
