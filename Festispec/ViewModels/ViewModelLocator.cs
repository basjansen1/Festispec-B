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
using Festispec.ViewModels.Factory;
using Festispec.ViewModels.Factory.Interface;
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
            SimpleIoc.Default.Register<ITemplateQuestionViewModelFactory, TemplateQuestionViewModelFactory>();

            SimpleIoc.Default.Register<IInspectionRepositoryFactory, InspectionRepositoryFactory>();

            // Register viewmodels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TemplateListViewModel>();
            SimpleIoc.Default.Register<TemplateAddViewModel>();
            SimpleIoc.Default.Register<TemplateUpdateViewModel>();
            SimpleIoc.Default.Register<AddQuestionViewModel>();
        }

        private static void RegisterNavigationService()
        {
            var navigationService = new NavigationService.NavigationService();
            navigationService.Configure(Routes.Routes.Home.Key, Routes.Routes.Home.PageType);
            navigationService.Configure(Routes.Routes.TemplateList.Key, Routes.Routes.TemplateList.PageType);
            navigationService.Configure(Routes.Routes.TemplateAdd.Key, Routes.Routes.TemplateAdd.PageType);
            navigationService.Configure(Routes.Routes.TemplateUpdate.Key, Routes.Routes.TemplateUpdate.PageType);
            navigationService.Configure(Routes.Routes.AddQuestion.Key, Routes.Routes.AddQuestion.PageType);

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

        #endregion

        #region Singleton ViewModels 

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public TemplateListViewModel TemplateList => ServiceLocator.Current.GetInstance<TemplateListViewModel>();
        public TemplateAddViewModel TemplateAdd => ServiceLocator.Current.GetInstance<TemplateAddViewModel>();
        public TemplateUpdateViewModel TemplateUpdate => ServiceLocator.Current.GetInstance<TemplateUpdateViewModel>();
        public AddQuestionViewModel AddQuestion => ServiceLocator.Current.GetInstance<AddQuestionViewModel>();

        #endregion

        #region ViewModels

        #endregion
    }
}