using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Festispec.Domain
{
    public partial class Schedule
    {
        [NotMapped]
        public bool IsDeleted { get; set; } = false;

        public sealed class ScheduleAttributes
        {
            [Display(Name = "Niet beschikbaar vanaf")]
            public DateTime NotAvailableFrom { get; set; }
            [Display(Name = "Niet beschikbaar tot")]
            public DateTime NotAvailableTo { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime NotAvailableDateFrom { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime NotAvailableDateTo { get; set; }
        }
    }
}