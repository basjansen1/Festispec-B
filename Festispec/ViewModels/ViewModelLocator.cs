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
using Festispec.ViewModels.Employee;
using Festispec.ViewModels.Employees;
using Festispec.ViewModels.Factory;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Inspector;
using Festispec.ViewModels.NavigationService;
using Festispec.ViewModels.Template;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Festispec.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            RegisterNavigationService();

            // Register repositories
            SimpleIoc.Default.Register<ITemplateRepositoryFactory, TemplateRepositoryFactory>();
            SimpleIoc.Default.Register<ITemplateViewModelFactory, TemplateViewModelFactory>();
            SimpleIoc.Default.Register<ITemplateQuestionRepositoryFactory, TemplateQuestionRepositoryFactory>();
            SimpleIoc.Default.Register<IQuestionTypeRepositoryFactory, QuestionTypeRepositoryFactory>();
            SimpleIoc.Default.Register<ITemplateQuestionViewModelFactory, TemplateQuestionViewModelFactory>();
            SimpleIoc.Default.Register<IInspectionRepositoryFactory, InspectionRepositoryFactory>();
            SimpleIoc.Default.Register<ICustomerRepositoryFactory, CustomerRepositoryFactory>();
            SimpleIoc.Default.Register<IEmployeeRepositoryFactory, EmployeeRepositoryFactory>();
            SimpleIoc.Default.Register<IEmployeeViewModelFactory, EmployeeViewModelFactory>();
            SimpleIoc.Default.Register<IEmployeeRoleRepositoryFactory, EmployeeRoleRepositoryFactory>();
            SimpleIoc.Default.Register<ILoginRepositoryFactory, LoginRepositoryFactory>();
            SimpleIoc.Default.Register<IInspectionRepositoryFactory, InspectionRepositoryFactory>();
            SimpleIoc.Default.Register<IInspectorRepositoryFactory, InspectorRepositoryFactory>();
            SimpleIoc.Default.Register<IInspectorViewModelFactory, InspectorViewModelFactory>();

            // Register viewmodels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<TemplateListViewModel>();
            SimpleIoc.Default.Register<TemplateAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<InspectionListVM>();
            SimpleIoc.Default.Register<AddInspectionVM>();
            SimpleIoc.Default.Register<EditInspectionVM>();
            SimpleIoc.Default.Register<ProcessInspectionVM>();
            SimpleIoc.Default.Register<TemplateQuestionAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<TemplateQuestionAddViewModel>();
            SimpleIoc.Default.Register<EmployeeAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<EmployeeListViewModel>();
            SimpleIoc.Default.Register<InspectorListViewModel>();
            SimpleIoc.Default.Register<InspectorAddOrUpdateViewModel>();
        }

        private static void RegisterNavigationService()
        {
            var navigationService = new NavigationService.NavigationService();
            navigationService.Configure(Routes.Routes.Home.Key, Routes.Routes.Home.PageType);
            navigationService.Configure(Routes.Routes.TemplateList.Key, Routes.Routes.TemplateList.PageType);
            navigationService.Configure(Routes.Routes.TemplateAddOrUpdate.Key,
                Routes.Routes.TemplateAddOrUpdate.PageType);
            navigationService.Configure(Routes.Routes.TemplateQuestionAddOrUpdate.Key,
                Routes.Routes.TemplateQuestionAddOrUpdate.PageType);
            navigationService.Configure(Routes.Routes.TemplateQuestionAdd.Key,
                Routes.Routes.TemplateQuestionAdd.PageType);
            navigationService.Configure(Routes.Routes.EmployeeAddOrUpdate.Key,
                Routes.Routes.EmployeeAddOrUpdate.PageType);
            navigationService.Configure(Routes.Routes.EmployeeList.Key, Routes.Routes.EmployeeList.PageType);
            navigationService.Configure(Routes.Routes.InspectorList.Key, Routes.Routes.InspectorList.PageType);
            navigationService.Configure(Routes.Routes.InspectorAddOrUpdate.Key,
                Routes.Routes.InspectorAddOrUpdate.PageType);

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
        }

        public static void Cleanup()
        {
        }

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

        #endregion

        #region Singleton ViewModels 

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public TemplateListViewModel TemplateList => ServiceLocator.Current.GetInstance<TemplateListViewModel>();

        public TemplateAddOrUpdateViewModel TemplateAddOrUpdate
            => ServiceLocator.Current.GetInstance<TemplateAddOrUpdateViewModel>();

        public TemplateQuestionAddOrUpdateViewModel TemplateQuestionAddOrUpdate
            => ServiceLocator.Current.GetInstance<TemplateQuestionAddOrUpdateViewModel>();

        public TemplateQuestionAddViewModel TemplateQuestionAdd
            => ServiceLocator.Current.GetInstance<TemplateQuestionAddViewModel>();

        public LoginViewModel LoginViewModel => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public EmployeeAddOrUpdateViewModel EmployeeAddOrUpdate =>
            ServiceLocator.Current.GetInstance<EmployeeAddOrUpdateViewModel>();

        public EmployeeListViewModel EmployeeList => ServiceLocator.Current.GetInstance<EmployeeListViewModel>();
        public InspectorListViewModel InspectorList => ServiceLocator.Current.GetInstance<InspectorListViewModel>();

        public InspectorAddOrUpdateViewModel InspectorAddOrUpdate =>
            ServiceLocator.Current.GetInstance<InspectorAddOrUpdateViewModel>();

        #endregion

        #region ViewModels

        public InspectionListVM GetInspectionList => ServiceLocator.Current.GetInstance<InspectionListVM>();

        public AddInspectionVM GetAddInspection => ServiceLocator.Current.GetInstance<AddInspectionVM>();

        public EditInspectionVM GetEditInspection => ServiceLocator.Current.GetInstance<EditInspectionVM>();

        public ProcessInspectionVM GetProcessInspection => ServiceLocator.Current.GetInstance<ProcessInspectionVM>();

        #endregion
    }
}