using System.ComponentModel.DataAnnotations.Schema;

namespace Festispec.Domain
{
    public partial class Planning
    {
        [NotMapped]
        public bool IsAdded { get; set; } = false;
    }
}