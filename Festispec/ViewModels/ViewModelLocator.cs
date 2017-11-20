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
using Festispec.ViewModels.RequestProcessing;
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

            // Register viewmodels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TemplateListViewModel>();
            SimpleIoc.Default.Register<TemplateAddOrUpdateViewModel>();
            SimpleIoc.Default.Register<TemplateQuestionAddOrUpdateViewModel>();
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

        #endregion

        #region Singleton ViewModels 

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public TemplateListViewModel TemplateList => ServiceLocator.Current.GetInstance<TemplateListViewModel>();

        public TemplateAddOrUpdateViewModel TemplateAddOrUpdate
            => ServiceLocator.Current.GetInstance<TemplateAddOrUpdateViewModel>();

        public TemplateQuestionAddOrUpdateViewModel AddQuestion
            => ServiceLocator.Current.GetInstance<TemplateQuestionAddOrUpdateViewModel>();

        #endregion
    }
}