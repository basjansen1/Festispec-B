using System.ComponentModel.DataAnnotations.Schema;

namespace Festispec.Domain
{
    public partial class Contact : IContact
    {
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}