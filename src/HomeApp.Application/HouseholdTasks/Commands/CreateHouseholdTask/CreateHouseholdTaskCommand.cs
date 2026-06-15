using HomeApp.Domain.Enums;
using MediatR;

namespace HomeApp.Application.HouseholdTasks.Commands;

public record CreateHouseholdTaskCommand(
    string Title,
    string Description,
    DateOnly? DueDate,
    Recurrence Recurrence,
    Guid? AssignedMemberId
) : IRequest<Guid>;