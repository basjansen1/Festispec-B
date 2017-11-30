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
using Festispec.ViewModels.Schedule;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Festispec.ViewModels.Schedules;

namespace Festispec.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Register steate
            SimpleIoc.Default.Register<IState, State.State>();

            // Register navigation
            RegisterNavigationService();

            // Register repositories
            SimpleIoc.Default.Register<ITemplateRepositoryFactory, TemplateRepositoryFactory>();
            SimpleIoc.Default.Register<ITemplateViewModelFactory, TemplateViewModelFactory>();
            SimpleIoc.Default.Register<ITemplateQuestionRepositoryFactory, TemplateQuestionRepositoryFactory>();
            SimpleIoc.Default.Register<IQuestionTypeRepositoryFactory, QuestionTypeRepositoryFactory>();
            SimpleIoc.Default.Register<ITemplateQuestionViewModelFactory, TemplateQuestionViewModelFactory>();
            SimpleIoc.Default.Register<IEmployeeRepositoryFactory, EmployeeRepositoryFactory>();
            SimpleIoc.Default.Register<IEmployeeViewModelFactory, EmployeeViewModelFactory>();
            SimpleIoc.Default.Register<IEmployeeRoleRepositoryFactory, EmployeeRoleRepositoryFactory>();
            SimpleIoc.Default.Register<ILoginRepositoryFactory, LoginRepositoryFactory>();
            SimpleIoc.Default.Register<IInspectionRepositoryFactory, InspectionRepositoryFactory>();
            SimpleIoc.Default.Register<IInspectorRepositoryFactory, InspectorRepositoryFactory>();
            SimpleIoc.Default.Register<IInspectorViewModelFactory, InspectorViewModelFactory>();
            SimpleIoc.Default.Register<IScheduleViewModelFactory, ScheduleViewModelFactory>();
            SimpleIoc.Default.Register<IScheduleRepositoryFactory, ScheduleRepositoryFactory>();

            // Register viewmodels
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TemplateListViewModel>();
            SimpleIoc.Default.Register<TemplateAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<EmployeeAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<EmployeeListViewModel>();
            SimpleIoc.Default.Register<InspectorListViewModel>();
            SimpleIoc.Default.Register<InspectorAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<ScheduleListViewModel>();
            SimpleIoc.Default.Register<ScheduleUpdateViewModel>();
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
            navigationService.Configure(Routes.Routes.ScheduleList);
            navigationService.Configure(Routes.Routes.InspectorAddOrUpdate);
            navigationService.Configure(Routes.Routes.ScheduleUpdate);
            navigationService.Configure(Routes.Routes.ScheduleView);

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

        public IScheduleViewModelFactory ScheduleViewModelFactory =
            ServiceLocator.Current.GetInstance<IScheduleViewModelFactory>();

        public INavigationService NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();


        #endregion

        #region Singleton ViewModels 

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public LoginViewModel LoginViewModel => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public EmployeeListViewModel EmployeeList => ServiceLocator.Current.GetInstance<EmployeeListViewModel>();
        public InspectorListViewModel InspectorList => ServiceLocator.Current.GetInstance<InspectorListViewModel>();
        public TemplateListViewModel TemplateList => ServiceLocator.Current.GetInstance<TemplateListViewModel>();
        public ScheduleListViewModel ScheduleList => ServiceLocator.Current.GetInstance<ScheduleListViewModel>();

        public TemplateAddOrUpdateViewModel TemplateAddOrUpdate => 
            ServiceLocator.Current.GetInstance<TemplateAddOrUpdateViewModel>();
        public TemplateQuestionAddViewModel TemplateQuestionAdd => 
            new TemplateQuestionAddViewModel(NavigationService, TemplateQuestionRepositoryFactory, TemplateQuestionViewModelFactory, QuestionTypeRepositoryFactory);
        public TemplateQuestionAddOrUpdateViewModel TemplateQuestionAddOrUpdate => 
            new TemplateQuestionAddOrUpdateViewModel(NavigationService, TemplateQuestionRepositoryFactory, TemplateQuestionViewModelFactory, QuestionTypeRepositoryFactory);
        public EmployeeAddOrUpdateViewModel EmployeeAddOrUpdate =>
            ServiceLocator.Current.GetInstance<EmployeeAddOrUpdateViewModel>();
        public InspectorAddOrUpdateViewModel InspectorAddOrUpdate =>
            ServiceLocator.Current.GetInstance<InspectorAddOrUpdateViewModel>();
        public ScheduleUpdateViewModel ScheduleUpdate => ServiceLocator.Current.GetInstance<ScheduleUpdateViewModel>();

        #endregion
    }
}