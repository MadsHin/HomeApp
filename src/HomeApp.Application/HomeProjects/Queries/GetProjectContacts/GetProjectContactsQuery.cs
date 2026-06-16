using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetProjectContactsQuery(Guid ProjectId) : IRequest<List<ProjectContactDto>>;
