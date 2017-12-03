using System;
using System.Collections.Generic;
using System.Linq;

namespace Festispec.Domain.Extension
{
    public static class DateRangeExtension
    {
        public static IEnumerable<DateTime> DateRange(this DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d).Date);
        }
    }
}
