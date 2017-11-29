namespace Festispec.ViewModels.Interface
{
    public interface IEntityViewModel<TEntity> where TEntity : class
    {
        TEntity Entity { get; }
        TEntity OriginalValues { get; }
        bool Save();
        bool Delete();
        void MapValues(TEntity from, TEntity to);
        void MapValuesFromOriginal();
        void MapValuesToOriginal();
    }
}