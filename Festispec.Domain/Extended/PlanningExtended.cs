using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festispec.Domain
{
    [MetadataType(typeof(PlanningAttributes))]
    public partial class Planning
    {
        [NotMapped]
        public bool IsAdded { get; set; } = false;

        public sealed class PlanningAttributes
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public Inspection Inspection { get; set; }
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public Inspector Inspector { get; set; }
        }
    }
}
