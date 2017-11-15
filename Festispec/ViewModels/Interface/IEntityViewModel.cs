namespace Festispec.ViewModels.Interface
{
    public interface IEntityViewModel<out TEntity> where TEntity : class
    {
        void Save();
        void Delete();
        TEntity Copy();
        TEntity Entity { get; }
    }
}