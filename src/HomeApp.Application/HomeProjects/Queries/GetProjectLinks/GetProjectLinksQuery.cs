using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetProjectLinksQuery(Guid ProjectId) : IRequest<List<ProjectLinkDto>>;
