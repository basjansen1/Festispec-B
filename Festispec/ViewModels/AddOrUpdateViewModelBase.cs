using System.ComponentModel;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels
{
    public abstract class AddOrUpdateViewModelBase<TViewModelFactory, TEntityViewModel, TEntity> :
        NavigatableViewModelBase,
        IAddOrUpdateViewModel
        where TViewModelFactory : IViewModelFactory<TEntityViewModel, TEntity>
        where TEntityViewModel : class, IEntityViewModel<TEntity>
        where TEntity : class
    {
        protected readonly TViewModelFactory ViewModelFactory;
        protected readonly IRepositoryFactory<TEntity> RepositoryFactory;

        protected AddOrUpdateViewModelBase(INavigationService navigationService,
            IRepositoryFactory<TEntity> repositoryFactory, TViewModelFactory viewModelFactory) : base(navigationService)
        {
            RepositoryFactory = repositoryFactory;
            ViewModelFactory = viewModelFactory;

            UpdateEntityViewModelFromNavigationParameter();

            NavigateBackCommand = new RelayCommand(() => NavigationService.GoBack());
            SaveEntityCommand = new RelayCommand(Save);

            NavigationService.PropertyChanged += OnNavigationServicePropertyChange;
        }

        public ICommand NavigateBackCommand { get; }
        public ICommand SaveEntityCommand { get; }

        public TEntityViewModel EntityViewModel { get; set; }

        public virtual void Save()
        {
            // TODO: Validation
            EntityViewModel.Save();

            NavigationService.GoBack(EntityViewModel);
        }

        public abstract void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args);

        protected virtual void UpdateEntityViewModelFromNavigationParameter()
        {
            var entityViewModel = NavigationService.Parameter as TEntityViewModel;
            // Create copy or new instance of TEntityViewModel
            EntityViewModel = entityViewModel != null
                ? ViewModelFactory.CreateViewModel(entityViewModel.Entity)
                : ViewModelFactory.CreateViewModel();
        }
    }
}