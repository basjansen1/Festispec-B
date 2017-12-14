using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Inspection;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using System.ComponentModel;
using System.Windows.Input;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Inspection
{
    public class InspectionQuestionnaireViewModel : AddOrUpdateViewModelBase<IInspectionViewModelFactory, InspectionVM, IInspectionRepository, Domain.Inspection>
    {
        public InspectionQuestionnaireViewModel(INavigationService navigationService, IInspectionRepositoryFactory repositoryFactory, IInspectionViewModelFactory viewModelFactory) : base(navigationService, repositoryFactory, viewModelFactory)
        {
        }
        public ICommand NavigateToQuestionAddCommand { get; set; }
        public ICommand NavigateToQuestionUpdateCommand { get; set; }
        public ICommand QuestionDeleteCommand { get; set; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.TemplateAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }
    }
}
