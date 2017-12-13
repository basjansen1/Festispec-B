using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festispec.Domain
{
    public partial class Schedule
    {
        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}