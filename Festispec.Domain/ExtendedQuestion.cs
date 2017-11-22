using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festispec.Domain
{
    public partial class Question
    {
        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}