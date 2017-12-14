/*
 In App.xaml:
 <Application.Resources>
     <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MusicCollectionMVVMLight.ViewModel"
                                  x:Key="Locator" />
 </Application.Resources>

 In the View:
 DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using Festispec.Domain.Repository;
using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.State;
using Festispec.ViewModels.CustomerCRUD;
using Festispec.ViewModels.Factory;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Employee;
using Festispec.ViewModels.Employees;
using Festispec.ViewModels.Inspector;
using Festispec.ViewModels.Planning;
using Festispec.ViewModels.Question;
using Festispec.ViewModels.Regulation;
using Festispec.ViewModels.Template;
using GalaSoft.MvvmLight.Ioc;
using GeodanApi;
using Microsoft.Practices.ServiceLocation;
using Festispec.ViewModels.Inspection;

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
            SimpleIoc.Default.Register<IQuestionRepositoryFactory>(() => new QuestionRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IQuestionTypeRepositoryFactory>(() => new QuestionTypeRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IEmployeeRepositoryFactory>(() => new EmployeeRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IEmployeeRoleRepositoryFactory>(() => new EmployeeRoleRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<ILoginRepositoryFactory>(() => new LoginRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IInspectionRepositoryFactory>(() => new InspectionRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IInspectorRepositoryFactory>(() => new InspectorRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IRegulationRepositoryFactory>(() => new RegulationRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<ICustomerRepositoryFactory>(() => new CustomerRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IPlanningRepositoryFactory>(() => new PlanningRepositoryFactory(state.IsOnline));
            SimpleIoc.Default.Register<IGeoRepositoryFactory, GeoRepositoryFactory>();



            // Register view model factories
            SimpleIoc.Default.Register<ITemplateViewModelFactory, TemplateViewModelFactory>();
            SimpleIoc.Default.Register<IQuestionViewModelFactory, QuestionViewModelFactory>();
            SimpleIoc.Default.Register<IEmployeeViewModelFactory, EmployeeViewModelFactory>();
            SimpleIoc.Default.Register<IInspectorViewModelFactory, InspectorViewModelFactory>();
            SimpleIoc.Default.Register<IPlanningViewModelFactory, PlanningViewModelFactory>();
            SimpleIoc.Default.Register<IRegulationsViewModelFactory, RegulationsViewModelFactory>();
            SimpleIoc.Default.Register<ICustomerViewModelFactory, CustomerViewModelFactory>();
            SimpleIoc.Default.Register<IInspectionViewModelFactory, InspectionViewModelFactory>();

            // Register APIs
            SimpleIoc.Default.Register<IGeodanSearchApi, GeodanSearchApi>();

            // Register viewmodels
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<TemplateListViewModel>();
            SimpleIoc.Default.Register<TemplateAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<InspectionQuestionnaireViewModel>();
            SimpleIoc.Default.Register<InspectionListVM>();
            SimpleIoc.Default.Register<AddInspectionVM>();
            SimpleIoc.Default.Register<EditInspectionVM>();
            SimpleIoc.Default.Register<EmployeeAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<EmployeeListViewModel>();
            SimpleIoc.Default.Register<InspectorListViewModel>();
            SimpleIoc.Default.Register<InspectorAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<RegulationListVM>();
            SimpleIoc.Default.Register<RegulationVM>();

            SimpleIoc.Default.Register<PlanningListViewModel>();
            SimpleIoc.Default.Register<PlanningAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<PlanningAddViewModel>();
            SimpleIoc.Default.Register<CustomerListViewModel>();
            SimpleIoc.Default.Register<CustomerAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<RegulationListViewModel>();
            SimpleIoc.Default.Register<RegulationAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<IGeodanSearchApi, GeodanSearchApi>();
            SimpleIoc.Default.Register<IGeoRepository, GeoRepository>();
            
        }

        private static void RegisterNavigationService()
        {
            var navigationService = new NavigationService.NavigationService(ServiceLocator.Current.GetInstance<IState>());
            navigationService.Configure(Routes.Routes.Home);
            navigationService.Configure(Routes.Routes.TemplateList);
            navigationService.Configure(Routes.Routes.TemplateAddOrUpdate);
            navigationService.Configure(Routes.Routes.EmployeeAddOrUpdate);
            navigationService.Configure(Routes.Routes.EmployeeList);
            navigationService.Configure(Routes.Routes.InspectorList);
            navigationService.Configure(Routes.Routes.InspectorAddOrUpdate);
            navigationService.Configure(Routes.Routes.InspectionList);
            navigationService.Configure(Routes.Routes.AddInspection);
            navigationService.Configure(Routes.Routes.EditInspection);
            navigationService.Configure(Routes.Routes.RegulationList);
            navigationService.Configure(Routes.Routes.ShowRegulation);
            navigationService.Configure(Routes.Routes.PlanningList);
            navigationService.Configure(Routes.Routes.PlanningAdd);
            navigationService.Configure(Routes.Routes.PlanningUpdate);
            navigationService.Configure(Routes.Routes.RegulationsAddOrUpdate);
            navigationService.Configure(Routes.Routes.CustomerAddOrUpdate);
            navigationService.Configure(Routes.Routes.CustomerList);
            navigationService.Configure(Routes.Routes.QuestionAdd);
            navigationService.Configure(Routes.Routes.InspectionQuestionnaire);

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
        }

        public static void Cleanup()
        {
        }

        #region Singleton Repositories

        public IRegulationRepositoryFactory RegulationRepositoryFactory =
            ServiceLocator.Current.GetInstance<IRegulationRepositoryFactory>();

        public IRegulationsViewModelFactory RegulationsViewModelFactory =
            ServiceLocator.Current.GetInstance<IRegulationsViewModelFactory>();

        public ITemplateRepositoryFactory TemplateRepositoryFactory =
            ServiceLocator.Current.GetInstance<ITemplateRepositoryFactory>();

        public ITemplateViewModelFactory TemplateViewModelFactory =
            ServiceLocator.Current.GetInstance<ITemplateViewModelFactory>();

        public IQuestionRepositoryFactory QuestionRepositoryFactory =
            ServiceLocator.Current.GetInstance<IQuestionRepositoryFactory>();

        public IQuestionViewModelFactory QuestionViewModelFactory =
            ServiceLocator.Current.GetInstance<IQuestionViewModelFactory>();

        public IInspectionRepositoryFactory InspectionRepositoryFactory =
            ServiceLocator.Current.GetInstance<IInspectionRepositoryFactory>();

        public IQuestionTypeRepositoryFactory QuestionTypeRepositoryFactory =
            ServiceLocator.Current.GetInstance<IQuestionTypeRepositoryFactory>();

        public IEmployeeRepositoryFactory EmployeeRepositoryFactory =
            ServiceLocator.Current.GetInstance<IEmployeeRepositoryFactory>();

        public ICustomerRepositoryFactory CustomerRepositoryFactory =
            ServiceLocator.Current.GetInstance<ICustomerRepositoryFactory>();

        public IEmployeeViewModelFactory EmployeeViewModelFactory =
            ServiceLocator.Current.GetInstance<IEmployeeViewModelFactory>();

        public IEmployeeRoleRepositoryFactory EmployeeRoleViewModelFactory =
            ServiceLocator.Current.GetInstance<IEmployeeRoleRepositoryFactory>();

        public IInspectorRepositoryFactory InspectorRepositoryFactory =
            ServiceLocator.Current.GetInstance<IInspectorRepositoryFactory>();

        public IInspectorViewModelFactory InspectorViewModelFactory =
            ServiceLocator.Current.GetInstance<IInspectorViewModelFactory>();

        public ICustomerViewModelFactory CustomerViewModelFactory =
            ServiceLocator.Current.GetInstance<ICustomerViewModelFactory>();

        public IPlanningRepositoryFactory PlanningRepositoryFactory = ServiceLocator.Current.GetInstance<IPlanningRepositoryFactory>();
        public IPlanningViewModelFactory PlanningViewModelFactory = ServiceLocator.Current.GetInstance<IPlanningViewModelFactory>();

        public IGeoRepository GeoRepository = ServiceLocator.Current.GetInstance<IGeoRepository>();
        public INavigationService NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();


        #endregion

        #region Singleton ViewModels 
        public CustomerAddOrUpdateViewModel CustomerAddOrUpdate =>
    ServiceLocator.Current.GetInstance<CustomerAddOrUpdateViewModel>();

        public CustomerListViewModel CustomerList =>
            ServiceLocator.Current.GetInstance<CustomerListViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public RegulationListViewModel RegulationsList => ServiceLocator.Current.GetInstance<RegulationListViewModel>();
        public RegulationAddOrUpdateViewModel RegulationsAddOrUpdate
            => ServiceLocator.Current.GetInstance<RegulationAddOrUpdateViewModel>();

        public TemplateListViewModel TemplateList => ServiceLocator.Current.GetInstance<TemplateListViewModel>();

        public TemplateAddOrUpdateViewModel TemplateAddOrUpdate
            => ServiceLocator.Current.GetInstance<TemplateAddOrUpdateViewModel>();
        public InspectionQuestionnaireViewModel InspectionQuestionnaire
            => ServiceLocator.Current.GetInstance<InspectionQuestionnaireViewModel>();

        public QuestionAddViewModel QuestionAdd => new QuestionAddViewModel(NavigationService, QuestionRepositoryFactory, QuestionViewModelFactory, QuestionTypeRepositoryFactory);

        public LoginViewModel LoginViewModel => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public EmployeeAddOrUpdateViewModel EmployeeAddOrUpdate =>
            ServiceLocator.Current.GetInstance<EmployeeAddOrUpdateViewModel>();

        public EmployeeListViewModel EmployeeList => ServiceLocator.Current.GetInstance<EmployeeListViewModel>();
        public InspectorListViewModel InspectorList => ServiceLocator.Current.GetInstance<InspectorListViewModel>();

        public InspectorAddOrUpdateViewModel InspectorAddOrUpdate =>
            ServiceLocator.Current.GetInstance<InspectorAddOrUpdateViewModel>();

        public PlanningListViewModel PlanningList => new PlanningListViewModel(NavigationService, PlanningRepositoryFactory, PlanningViewModelFactory);
        public PlanningAddOrUpdateViewModel PlanningAddOrUpdate => new PlanningAddOrUpdateViewModel(NavigationService, PlanningRepositoryFactory, PlanningViewModelFactory, InspectorRepositoryFactory);
        public PlanningAddViewModel PlanningAdd => new PlanningAddViewModel(NavigationService, PlanningRepositoryFactory, PlanningViewModelFactory, InspectorRepositoryFactory);

        #endregion

        #region ViewModels

        public InspectionListVM GetInspectionList => ServiceLocator.Current.GetInstance<InspectionListVM>();

        public RegulationListVM GetRegulationList => new RegulationListVM(RegulationRepositoryFactory, NavigationService, GetInspectionList);

        public AddInspectionVM GetAddInspectionVM => new AddInspectionVM(GetInspectionList, CustomerRepositoryFactory, InspectionRepositoryFactory, NavigationService, GeoRepository);

        public EditInspectionVM GetEditInspection => ServiceLocator.Current.GetInstance<EditInspectionVM>();

        #endregion
    }
}