using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record RemoveMaterialFromProjectCommand(Guid HomeProjectId, Guid MaterialId) : IRequest;
