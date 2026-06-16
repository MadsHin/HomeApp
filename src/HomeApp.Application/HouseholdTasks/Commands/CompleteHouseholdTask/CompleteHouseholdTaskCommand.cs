using MediatR;

namespace HomeApp.Application.HouseholdTasks.Commands;

public record CompleteHouseholdTaskCommand(Guid Id) : IRequest;
