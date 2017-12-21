using System.Data.Entity.Spatial;

namespace Festispec.Domain
{
    public interface IAddress
    {
        int Id { get; set; }
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