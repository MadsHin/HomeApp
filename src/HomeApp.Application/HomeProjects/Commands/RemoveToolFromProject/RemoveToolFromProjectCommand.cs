using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record RemoveToolFromProjectCommand(Guid HomeProjectId, Guid ToolId) : IRequest;
