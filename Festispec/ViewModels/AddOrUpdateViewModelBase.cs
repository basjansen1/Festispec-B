using System.ComponentModel;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Interface;
using Festispec.ViewModels.NavigationService;
using Festispec.ViewModels.Template;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels
{
    public abstract class AddOrUpdateViewModelBase<TViewModelFactory, TEntityViewModel, TEntity> : NavigatableViewModelBase,
        IAddOrUpdateViewModel
        where TViewModelFactory : IViewModelFactory<TEntityViewModel, TEntity>
        where TEntityViewModel : class, IEntityViewModel<TEntity>
        where TEntity : class
    {
        protected readonly IRepositoryFactory<TEntity> RepositoryFactory;
        private readonly TViewModelFactory _viewModelFactory;
        public ICommand NavigateBackCommand { get; }
        public ICommand SaveEntityCommand { get; }

        public TEntityViewModel EntityViewModel { get; set; }

        protected AddOrUpdateViewModelBase(INavigationService navigationService,
            IRepositoryFactory<TEntity> repositoryFactory, TViewModelFactory viewModelFactory) : base(navigationService)
        {
            RepositoryFactory = repositoryFactory;
            _viewModelFactory = viewModelFactory;

            UpdateEntityViewModelFromNavigationParameter();

            NavigateBackCommand = new RelayCommand(() => NavigationService.GoBack());
            SaveEntityCommand = new RelayCommand(Save);

            NavigationService.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.TemplateUpdate.Key &&
                NavigationService.CurrentPageKey != Routes.Routes.TemplateAdd.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        private void UpdateEntityViewModelFromNavigationParameter()
        {
            var entityViewModel = NavigationService.Parameter as TEntityViewModel;
            // Create copy or new instance of TEntityViewModel
            EntityViewModel = entityViewModel != null ? _viewModelFactory.CreateViewModel(entityViewModel.Entity) : _viewModelFactory.CreateViewModel();
        }

        public virtual void Save()
        {
            // TODO: Validation
            EntityViewModel.Save();

            NavigationService.GoBack(EntityViewModel);
        }
    }
}