namespace Festispec.ViewModels.Interface
{
    public interface IEntityViewModel<out TEntity> where TEntity : class
    {
        bool Save();
        bool Delete();
        TEntity Copy();
        TEntity Entity { get; }
    }
}