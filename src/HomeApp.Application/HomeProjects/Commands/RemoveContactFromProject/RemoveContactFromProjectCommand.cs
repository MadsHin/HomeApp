using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record RemoveContactFromProjectCommand(Guid HomeProjectId, Guid ContactId) : IRequest;
