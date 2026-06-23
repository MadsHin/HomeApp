namespace HomeApp.Domain.Entities;

public class MaintenanceTask
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Notes { get; set; }
    public DateOnly? LastDone { get; set; }
    public DateOnly? ScheduleAnchor { get; set; }
    public MaintenanceScheduleType ScheduleType { get; set; } = MaintenanceScheduleType.Interval;
    public int? IntervalMonths { get; set; }
    public string? AnnualDates { get; set; }
    public DateOnly? OneTimeDate { get; set; }
}
