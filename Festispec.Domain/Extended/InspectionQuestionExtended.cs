using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.Domain
{
    [MetadataType(typeof(InspectionQuestionAttributes))]
    public partial class InspectionQuestion
    {
        public sealed class InspectionQuestionAttributes
        {
            [Key]
            public int Inspection_Id { get; set; }
            [Key]
            public int Question_Id { get; set; }
        }
    }
}
