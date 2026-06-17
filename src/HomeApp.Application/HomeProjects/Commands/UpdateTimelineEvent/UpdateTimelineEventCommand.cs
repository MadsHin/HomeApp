using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record UpdateTimelineEventCommand(
    Guid Id,
    string Title,
    DateOnly? Date
) : IRequest;
