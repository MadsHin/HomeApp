using MediatR;

namespace HomeApp.Application.MaintenanceTasks.Commands;

public record DeleteMaintenanceTaskCommand(Guid Id) : IRequest;
