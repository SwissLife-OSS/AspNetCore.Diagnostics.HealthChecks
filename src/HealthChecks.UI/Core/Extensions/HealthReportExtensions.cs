using HealthChecks.UI.Core;
using HealthChecks.UI.Core.Data;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Extensions.Diagnostics.HealthChecks
{
    public static class HealthReportExtensions
    {
        public static List<HealthCheckExecutionEntry> ToExecutionEntries(this UIHealthReport report)
        {
            if (report.Entries!=null && report.Entries.Any())
            {
                return report.Entries
                    .Select(item => new HealthCheckExecutionEntry()
                    {
                        Name = item.Key,
                        Status = item.Value.Status,
                        Description = item.Value.Description,
                        Duration = item.Value.Duration,
                        Tags = item.Value.Tags?.ToList() ?? null
                    }).ToList();
            }

            return new List<HealthCheckExecutionEntry>();

        }
    }
}
