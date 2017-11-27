﻿using Festispec.NavigationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Festispec.ViewModels.Regulations
{
    public class RegulationsAddOrUpdateViewModel : 
        AddOrUpdateViewModelBase<IRegulationsViewModelFactory, RegulationsViewModel, IRegulationsRepository, Domain.Employee>
    {
        public RegulationsAddOrUpdateViewModel(INavigationService navigationService,
            IRegulationsRepositoryFactory repositoryFactory,
            IRegulationsRoleRepositoryFactory regulationsRoleRepositoryFactory,
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
