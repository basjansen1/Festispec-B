/*
 In App.xaml:
 <Application.Resources>
     <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MusicCollectionMVVMLight.ViewModel"
                                  x:Key="Locator" />
 </Application.Resources>

 In the View:
 DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

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

            // Register repositories
            SimpleIoc.Default.Register<ITemplateRepositoryFactory, TemplateRepositoryFactory>();
            SimpleIoc.Default.Register<ITemplateViewModelFactory, TemplateViewModelFactory>();

            // Register viewmodels
            SimpleIoc.Default.Register<TemplateListViewModel>();
        }

        #region Singleton Repositories
        public ITemplateRepositoryFactory TemplateRepositoryFactory = ServiceLocator.Current.GetInstance<ITemplateRepositoryFactory>();
        public ITemplateViewModelFactory TemplateViewModelFactory = ServiceLocator.Current.GetInstance<ITemplateViewModelFactory>();
        #endregion

        #region Singleton ViewModels 
        public TemplateListViewModel TemplateList => ServiceLocator.Current.GetInstance<TemplateListViewModel>();
        #endregion

        #region ViewModels
        #endregion

        public static void Cleanup()
        {
        }
    }
}
