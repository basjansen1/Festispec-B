using System.ComponentModel;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels
{
    public abstract class AddOrUpdateViewModelBase<TViewModelFactory, TEntityViewModel, TRepository, TEntity> :
        NavigatableViewModelBase,
        IAddOrUpdateViewModel
        where TViewModelFactory : IViewModelFactory<TEntityViewModel, TEntity>
        where TEntityViewModel : class, IEntityViewModel<TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly TViewModelFactory ViewModelFactory;
        protected readonly IRepositoryFactory<TRepository, TEntity> RepositoryFactory;

        protected AddOrUpdateViewModelBase(INavigationService navigationService,
            IRepositoryFactory<TRepository, TEntity> repositoryFactory, TViewModelFactory viewModelFactory) : base(navigationService)
        {
            RepositoryFactory = repositoryFactory;
            ViewModelFactory = viewModelFactory;

            UpdateEntityViewModelFromNavigationParameter();

            NavigateBackCommand = new RelayCommand(GoBack);
            SaveEntityCommand = new RelayCommand(Save);
            CancelEntityCommand = new RelayCommand(Cancel);

            NavigationService.PropertyChanged += OnNavigationServicePropertyChange;
        }

        public ICommand NavigateBackCommand { get; }
        public ICommand SaveEntityCommand { get; }
        public ICommand CancelEntityCommand { get; }

        public TEntityViewModel EntityViewModel { get; set; }

        public void Save(object backParameter)
        {
            var saved = EntityViewModel.Save();

            // Return is save failed
            if (!saved)
                return;

            // Overwrite the original values with the new entity values
            EntityViewModel.MapValuesToOriginal();

            GoBack(backParameter);
        }

        public virtual void Save()
        {
            Save(EntityViewModel);
        }

        public virtual void Cancel()
        {
            EntityViewModel.MapValuesFromOriginal();

            GoBack(EntityViewModel);
        }

        public virtual void GoBack()
        {
            GoBack(null);
        }

        public virtual void GoBack(object parameter)
        {
            NavigationService.GoBack(parameter);
        }

        public abstract void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args);

        protected virtual void UpdateEntityViewModelFromNavigationParameter()
        {
            var entityViewModel = NavigationService.Parameter as TEntityViewModel;

            EntityViewModel = entityViewModel ?? ViewModelFactory.CreateViewModel();
        }
    }
}