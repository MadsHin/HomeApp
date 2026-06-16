using HomeApp.Domain.Enums;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record ChangeProjectStatusCommand(Guid Id, ProjectStatus Status) : IRequest;
