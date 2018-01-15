using System.ComponentModel.DataAnnotations.Schema;

namespace Festispec.Domain
{
    public partial class Inspector
    {
        [NotMapped] public int Distance { get; set; }
    }
}