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
            SimpleIoc.Default.Register<IInspectionRepositoryFactory, InspectionRepositoryFactory>();
            
            // Register viewmodels
//            SimpleIoc.Default.Register<AAAViewModel>();
        }

        #region Singleton Repositories
        public IInspectionRepositoryFactory InspectionRepositoryFactory = ServiceLocator.Current.GetInstance<IInspectionRepositoryFactory>();
        #endregion

        #region Singleton ViewModels 
//        public AAAViewModel Test => ServiceLocator.Current.GetInstance<AAAViewModel>();
        #endregion

        #region ViewModels
        #endregion

        public static void Cleanup()
        {
        }
    }
}
