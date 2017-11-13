namespace Festispec.ViewModels.Interface
{
    public interface IEntityViewModel<out TEntity> where TEntity : class
    {
        void Save();
        TEntity Entity { get; }
    }
}