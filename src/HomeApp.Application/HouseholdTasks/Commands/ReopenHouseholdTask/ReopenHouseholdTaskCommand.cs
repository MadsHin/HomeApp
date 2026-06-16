using MediatR;

namespace HomeApp.Application.HouseholdTasks.Commands;

public record ReopenHouseholdTaskCommand(Guid Id) : IRequest;
