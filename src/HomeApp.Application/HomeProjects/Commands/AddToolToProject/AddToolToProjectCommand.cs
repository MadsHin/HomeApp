using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record AddToolToProjectCommand(Guid HomeProjectId, Guid ToolId) : IRequest;
