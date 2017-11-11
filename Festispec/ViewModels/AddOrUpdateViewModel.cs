using System.Windows.Input;
using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Template;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels
{
    public abstract class AddOrUpdateViewModel<TRepository, TEntityViewModel, TEntity> : ViewModelBase,
        IAddOrUpdateViewModel
        where TRepository : IRepository<TEntity>
        where TEntityViewModel : IEntityViewModel
        where TEntity : class
    {
        protected readonly IRepositoryFactory<TRepository> RepositoryFactory;
        public readonly ICommand SaveTemplate;

        public TEntityViewModel EntityViewModel;

        protected AddOrUpdateViewModel(IRepositoryFactory<TRepository> repositoryFactory)
        {
            RepositoryFactory = repositoryFactory;

            SaveTemplate = new RelayCommand(Save);
        }

        public void Save()
        {
            EntityViewModel.Save();
        }
    }
}