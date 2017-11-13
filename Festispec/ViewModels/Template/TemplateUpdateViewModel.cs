﻿using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;

namespace Festispec.ViewModels.Template
{
    public class TemplateUpdateViewModel : TemplateAddOrUpdateViewModel
    {
        public TemplateUpdateViewModel(INavigationService navigationService, ITemplateRepositoryFactory repositoryFactory, ITemplateViewModelFactory templateViewModelFactory)
            : base(navigationService, repositoryFactory, templateViewModelFactory)
        {
        }
    }
}