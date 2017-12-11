using System.Data.Entity.Spatial;
using Festispec.Domain;

namespace Festispec.ViewModels.Interface
{
    public interface IAddressViewModel<TEntity> : IEntityViewModel<TEntity>
        where TEntity : class, IAddress
    {
        int Id { get; }
        string Street { get; set; }
        string HouseNumber { get; set; }
        string PostalCode { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string Municipality { get; set; }
        DbGeography Location { get; set; }
        double Long { get; set; }
        double Lat { get; set; }
    }
}