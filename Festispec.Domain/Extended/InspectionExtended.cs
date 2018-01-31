using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Festispec.Domain.Extension;

namespace Festispec.Domain
{
    public partial class Inspection
    {
        [NotMapped]
        public IEnumerable<DateTime> Dates => Start.DateRange(End);
    }
}