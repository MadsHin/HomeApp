using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record AddProjectLinkCommand(
    Guid HomeProjectId,
    string Label,
    string Url
) : IRequest<Guid>;
