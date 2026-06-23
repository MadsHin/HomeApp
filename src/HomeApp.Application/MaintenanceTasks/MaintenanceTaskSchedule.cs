using HomeApp.Domain.Entities;

namespace HomeApp.Application.MaintenanceTasks;

internal static class MaintenanceTaskSchedule
{
    internal static DateOnly? NextDue(MaintenanceTask t, DateOnly today) => t.ScheduleType switch
    {
        MaintenanceScheduleType.Interval =>
            t.IntervalMonths.HasValue
                ? (t.ScheduleAnchor ?? t.LastDone ?? today).AddMonths(t.IntervalMonths.Value)
                : null,

        MaintenanceScheduleType.AnnualDates =>
            NextAnnualDate(t.AnnualDates, t.ScheduleAnchor ?? t.LastDone ?? today),

        MaintenanceScheduleType.OneTime => t.LastDone.HasValue ? null : t.OneTimeDate,

        _ => null
    };

    // Returns the first annual date strictly after `notBefore`.
    // Uses <= so that the anchor date itself is skipped (next cycle starts after it).
    internal static DateOnly? NextAnnualDate(string? annualDates, DateOnly notBefore)
    {
        if (string.IsNullOrWhiteSpace(annualDates)) return null;

        DateOnly? nearest = null;
        foreach (string part in annualDates.Split(','))
        {
            string[] seg = part.Trim().Split('-');
            if (seg.Length != 2) continue;
            if (!int.TryParse(seg[0], out int month) || !int.TryParse(seg[1], out int day)) continue;

            DateOnly candidate;
            try { candidate = new DateOnly(notBefore.Year, month, day); }
            catch { continue; }

            if (candidate <= notBefore) candidate = candidate.AddYears(1);
            if (nearest is null || candidate < nearest) nearest = candidate;
        }
        return nearest;
    }
}
