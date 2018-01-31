using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Festispec.Web.Models
{
    public class ScheduleViewModel
    {
        [Required]
        [Display(Name = "NotAvailableFrom")]
        public string NotAvailableFrom { get; set; }

        [Required]
        [Display(Name = "NotAvailableTo")]
        public string NotAvailableTo { get; set; }
    }
}