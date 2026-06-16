using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetProjectMaterialsQuery(Guid ProjectId) : IRequest<List<ProjectMaterialDto>>;
