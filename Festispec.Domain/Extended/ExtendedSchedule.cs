using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Festispec.Domain
{
    public partial class Schedule : IValidatableObject
    {
        [NotMapped]
        public bool IsDeleted { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            DateTime from = new DateTime(1970, 1, 1);

            if (NotAvailableFrom < from)
            {
                results.Add(new ValidationResult("ERROR: Minimaal 1/1/1970", new[] { "NotAvailableFrom" }));
            }

            if (NotAvailableTo < NotAvailableFrom)
            {
                results.Add(new ValidationResult("ERROR: Niet beschikbaar tot mag niet eerder zijn dan Niet beschikbaar vanaf", new[] { "NotAvailableTo" }));
            }

            return results;
        }

        public sealed class ScheduleAttributes
        {
            [Display(Name = "Niet beschikbaar vanaf")]
            public DateTime NotAvailableFrom { get; set; }
            [Display(Name = "Niet beschikbaar tot")]
            public DateTime NotAvailableTo { get; set; }

            [Required]
            [Range(typeof(DateTime), "1/1/1970", "1/1/2100")]
            public DateTime NotAvailableDateFrom { get; set; }

            [Required]
            [Range(typeof(DateTime), "1/1/1970", "1/1/2100")]
            public DateTime NotAvailableDateTo { get; set; }
        }
    }
}