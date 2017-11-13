using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festispec.ViewModels.NavigationService;
using Festispec.ViewModels.Template;
using Festispec.ViewModels.Factory.Interface;
using Festispec.Domain.Repository.Factory.Interface;
using System.ComponentModel;

namespace Festispec.ViewModels
{
    public class AddQuestionViewModel : AddOrUpdateViewModelBase<ITemplateQuestionViewModelFactory, TemplateQuestionViewModel, Domain.TemplateQuestion>
    {
        
        public AddQuestionViewModel(INavigationService navigationService, ITemplateQuestionRepositoryFactory RepositoryFactory, ITemplateQuestionViewModelFactory TemplateVMFactory) : base(navigationService, RepositoryFactory, TemplateVMFactory)
        {
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.AddQuestion.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            NavigationService.GoBack(EntityViewModel);
        }

    }
}
