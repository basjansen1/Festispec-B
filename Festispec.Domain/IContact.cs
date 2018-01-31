namespace Festispec.Domain
{
    public interface IContact : IAddress
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Telephone { get; set; }
        string IBAN { get; set; }
    }
}