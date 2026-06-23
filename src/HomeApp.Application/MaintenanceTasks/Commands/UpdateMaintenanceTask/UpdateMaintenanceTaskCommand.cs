using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.MaintenanceTasks.Commands;

public record UpdateMaintenanceTaskCommand(
    Guid Id,
    string Title,
    string? Notes,
    DateOnly? LastDone,
    MaintenanceScheduleType ScheduleType,
    int? IntervalMonths,
    string? AnnualDates,
    DateOnly? OneTimeDate
) : IRequest;
