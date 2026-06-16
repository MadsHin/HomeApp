using HomeApp.Domain.Enums;

namespace HomeApp.Application.HouseholdTasks.Queries;

public record HouseholdTaskDto(
    Guid Id,
    string Title,
    string? Description,
    DateOnly? DueDate,
    bool IsCompleted,
    Recurrence Recurrence,
    Guid? AssignedMemberId
);