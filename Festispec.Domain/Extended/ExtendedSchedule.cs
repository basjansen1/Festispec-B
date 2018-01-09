using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Festispec.Domain
{
    [MetadataType(typeof(ScheduleAttributes))]
    public partial class Schedule : IValidatableObject
    {
        [NotMapped]
        public bool IsDeleted { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (NotAvailableTo <= NotAvailableFrom)
            {
                results.Add(new ValidationResult("ERROR: Niet beschikbaar tot mag niet eerder zijn dan Niet beschikbaar vanaf", new[] { "NotAvailableTo" }));
            }

            return results;
        }

        public sealed class ScheduleAttributes
        {
            [Display(Name = "Niet beschikbaar vanaf")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            [Range(typeof(DateTime), "1/1/1970", "1/1/2200")]
            public DateTime NotAvailableFrom { get; set; }

            [Display(Name = "Niet beschikbaar tot")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            [Range(typeof(DateTime), "1/1/1970", "1/1/2200")]
            public DateTime NotAvailableTo { get; set; }
        }
    }
}