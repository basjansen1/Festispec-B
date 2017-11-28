using Festispec.NavigationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Festispec.ViewModels.Factory.Interface;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.ViewModels.Regulations
{
    public class RegulationsAddOrUpdateViewModel : 
        AddOrUpdateViewModelBase<IRegulationsViewModelFactory, RegulationsViewModel, IRegulationsRepository, Domain.Regulation>
    {
        public RegulationsAddOrUpdateViewModel(INavigationService navigationService,
            IRegulationsRepositoryFactory repositoryFactory,
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
