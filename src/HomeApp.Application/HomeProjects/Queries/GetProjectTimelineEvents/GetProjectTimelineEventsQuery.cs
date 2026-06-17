using MediatR;

namespace HomeApp.Application.HomeProjects.Queries;

public record GetProjectTimelineEventsQuery(Guid ProjectId) : IRequest<List<ProjectTimelineEventDto>>;
