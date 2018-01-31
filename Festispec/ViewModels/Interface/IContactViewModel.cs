using Festispec.Domain;

namespace Festispec.ViewModels.Interface
{
    public interface IContactViewModel<TEntity> : IAddressViewModel<TEntity>
        where TEntity : class, IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Telephone { get; set; }
        string IBAN { get; set; }
    }
}