using MediatR;

namespace HomeApp.Application.MaintenanceTasks.Commands;

public record MarkTaskDoneCommand(Guid Id) : IRequest;
