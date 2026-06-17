using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetProjectToolsQuery(Guid HomeProjectId) : IRequest<List<HomeProjectToolDto>>;
