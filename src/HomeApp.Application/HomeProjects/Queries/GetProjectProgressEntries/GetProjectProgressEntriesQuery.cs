using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetProjectProgressEntriesQuery(Guid ProjectId) : IRequest<List<ProgressEntryDto>>;
