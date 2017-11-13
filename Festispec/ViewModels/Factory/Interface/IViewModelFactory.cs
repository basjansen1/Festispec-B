using Festispec.ViewModels.Interface;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface IViewModelFactory<out TViewModel, in TEntity> where TViewModel : IEntityViewModel<TEntity>
        where TEntity : class
    {
        TViewModel CreateViewModel();
        TViewModel CreateViewModel(TEntity entity);
    }
}