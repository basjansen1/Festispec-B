/*
 In App.xaml:
 <Application.Resources>
     <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MusicCollectionMVVMLight.ViewModel"
                                  x:Key="Locator" />
 </Application.Resources>

 In the View:
 DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.State;
using Festispec.ViewModels.Factory;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Employee;
using Festispec.ViewModels.Employees;
using Festispec.ViewModels.Inspector;
using Festispec.ViewModels.Template;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Festispec.ViewModels.Regulations;

namespace Festispec.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Register steate
            var state = new State.State();
            SimpleIoc.Default.Register<IState>(() => state);

            // Register navigation
            RegisterNavigationService();

            // Register repository factories
            SimpleIoc.Default.Register<ITemplateRepositoryFactory>(() => new TemplateRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<ITemplateQuestionRepositoryFactory>(() => new TemplateQuestionRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IQuestionTypeRepositoryFactory>(() => new QuestionTypeRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IEmployeeRepositoryFactory>(() => new EmployeeRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IEmployeeRoleRepositoryFactory>(() => new EmployeeRoleRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<ILoginRepositoryFactory>(() => new LoginRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IInspectionRepositoryFactory>(() => new InspectionRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IInspectorRepositoryFactory>(() => new InspectorRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IRegulationsRepositoryFactory>(() => new RegulationsRepositoryFactory(state.IsOnline));

            // Register view model factories
            SimpleIoc.Default.Register<ITemplateViewModelFactory, TemplateViewModelFactory>();
            SimpleIoc.Default.Register<ITemplateQuestionViewModelFactory, TemplateQuestionViewModelFactory>();
            SimpleIoc.Default.Register<IEmployeeViewModelFactory, EmployeeViewModelFactory>();
            SimpleIoc.Default.Register<IInspectorViewModelFactory, InspectorViewModelFactory>();
            SimpleIoc.Default.Register<IRegulationsViewModelFactory, RegulationsViewModelFactory>();

            // Register viewmodels
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TemplateListViewModel>();
            SimpleIoc.Default.Register<TemplateAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<EmployeeAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<EmployeeListViewModel>();
            SimpleIoc.Default.Register<InspectorListViewModel>();
            SimpleIoc.Default.Register<InspectorAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<RegulationsListViewModel>();
            SimpleIoc.Default.Register<RegulationsAddOrUpdateViewModel>();
        }

        private static void RegisterNavigationService()
        {
            var navigationService = new NavigationService.NavigationService(ServiceLocator.Current.GetInstance<IState>());
            navigationService.Configure(Routes.Routes.Home);
            navigationService.Configure(Routes.Routes.TemplateList);
            navigationService.Configure(Routes.Routes.TemplateAddOrUpdate);
            navigationService.Configure(Routes.Routes.TemplateQuestionAddOrUpdate);
            navigationService.Configure(Routes.Routes.TemplateQuestionAdd);
            navigationService.Configure(Routes.Routes.EmployeeAddOrUpdate);
            navigationService.Configure(Routes.Routes.EmployeeList);
            navigationService.Configure(Routes.Routes.InspectorList);
            navigationService.Configure(Routes.Routes.InspectorAddOrUpdate);
            navigationService.Configure(Routes.Routes.RegulationsList);
            navigationService.Configure(Routes.Routes.RegulationsAddOrUpdate);

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
        }

        public static void Cleanup()
        {
        }

        #region ViewModels

        public InspectionListVM GetInspectionList()
        {
            return new InspectionListVM(InspectionRepositoryFactory);
        }

        #endregion

        #region Singleton Repositories

        public IRegulationsRepositoryFactory RegulationsRepositoryFactory =
            ServiceLocator.Current.GetInstance<IRegulationsRepositoryFactory>();

        public IRegulationsViewModelFactory RegulationsViewModelFactory =
            ServiceLocator.Current.GetInstance<IRegulationsViewModelFactory>();

        public ITemplateRepositoryFactory TemplateRepositoryFactory =
            ServiceLocator.Current.GetInstance<ITemplateRepositoryFactory>();

        public ITemplateViewModelFactory TemplateViewModelFactory =
            ServiceLocator.Current.GetInstance<ITemplateViewModelFactory>();

        public ITemplateQuestionRepositoryFactory TemplateQuestionRepositoryFactory =
            ServiceLocator.Current.GetInstance<ITemplateQuestionRepositoryFactory>();

        public ITemplateQuestionViewModelFactory TemplateQuestionViewModelFactory =
            ServiceLocator.Current.GetInstance<ITemplateQuestionViewModelFactory>();

        public IInspectionRepositoryFactory InspectionRepositoryFactory =
            ServiceLocator.Current.GetInstance<IInspectionRepositoryFactory>();

        public IQuestionTypeRepositoryFactory QuestionTypeRepositoryFactory =
            ServiceLocator.Current.GetInstance<IQuestionTypeRepositoryFactory>();

        public IEmployeeRepositoryFactory EmployeeRepositoryFactory =
            ServiceLocator.Current.GetInstance<IEmployeeRepositoryFactory>();

        public IEmployeeViewModelFactory EmployeeViewModelFactory =
            ServiceLocator.Current.GetInstance<IEmployeeViewModelFactory>();

        public IEmployeeRoleRepositoryFactory EmployeeRoleViewModelFactory =
            ServiceLocator.Current.GetInstance<IEmployeeRoleRepositoryFactory>();

        public IInspectorRepositoryFactory InspectorRepositoryFactory =
            ServiceLocator.Current.GetInstance<IInspectorRepositoryFactory>();

        public IInspectorViewModelFactory InspectorViewModelFactory =
            ServiceLocator.Current.GetInstance<IInspectorViewModelFactory>();

        public INavigationService NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();


        #endregion

        #region Singleton ViewModels 

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public RegulationsListViewModel RegulationsList => ServiceLocator.Current.GetInstance<RegulationsListViewModel>();
        public RegulationsAddOrUpdateViewModel RegulationsAddOrUpdate
            => ServiceLocator.Current.GetInstance<RegulationsAddOrUpdateViewModel>();

        public TemplateListViewModel TemplateList => ServiceLocator.Current.GetInstance<TemplateListViewModel>();

        public TemplateAddOrUpdateViewModel TemplateAddOrUpdate
            => ServiceLocator.Current.GetInstance<TemplateAddOrUpdateViewModel>();

        public TemplateQuestionAddOrUpdateViewModel TemplateQuestionAddOrUpdate => new TemplateQuestionAddOrUpdateViewModel(NavigationService, TemplateQuestionRepositoryFactory, TemplateQuestionViewModelFactory, QuestionTypeRepositoryFactory);
            
        public TemplateQuestionAddViewModel TemplateQuestionAdd => new TemplateQuestionAddViewModel(NavigationService, TemplateQuestionRepositoryFactory, TemplateQuestionViewModelFactory, QuestionTypeRepositoryFactory);

        public LoginViewModel LoginViewModel => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public EmployeeAddOrUpdateViewModel EmployeeAddOrUpdate =>
            ServiceLocator.Current.GetInstance<EmployeeAddOrUpdateViewModel>();

        public EmployeeListViewModel EmployeeList => ServiceLocator.Current.GetInstance<EmployeeListViewModel>();
        public InspectorListViewModel InspectorList => ServiceLocator.Current.GetInstance<InspectorListViewModel>();

        public InspectorAddOrUpdateViewModel InspectorAddOrUpdate =>
            ServiceLocator.Current.GetInstance<InspectorAddOrUpdateViewModel>();

        #endregion
    }
}