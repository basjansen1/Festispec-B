using System.ComponentModel.DataAnnotations.Schema;

namespace Festispec.Domain
{
    public partial class Contact
    {
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}