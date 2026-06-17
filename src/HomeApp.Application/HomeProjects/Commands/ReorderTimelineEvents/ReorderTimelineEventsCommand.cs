using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record ReorderTimelineEventsCommand(List<Guid> OrderedIds) : IRequest;
