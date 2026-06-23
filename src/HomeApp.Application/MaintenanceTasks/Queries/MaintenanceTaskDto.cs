using HomeApp.Domain.Entities;

namespace HomeApp.Application.MaintenanceTasks.Queries;

public record MaintenanceTaskDto(
    Guid Id,
    string Title,
    string? Notes,
    DateOnly? LastDone,
    MaintenanceScheduleType ScheduleType,
    int? IntervalMonths,
    string? AnnualDates,
    DateOnly? OneTimeDate,
    DateOnly? NextDue
);
