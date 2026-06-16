using MediatR;

namespace HomeApp.Application.HouseholdTasks.Commands;

public record DeleteHouseholdTaskCommand(Guid Id) : IRequest;
