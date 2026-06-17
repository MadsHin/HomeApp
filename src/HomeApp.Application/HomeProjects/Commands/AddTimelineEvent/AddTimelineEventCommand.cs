using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record AddTimelineEventCommand(
    Guid HomeProjectId,
    string Title,
    DateOnly? Date
) : IRequest;
