using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record DeleteTimelineEventCommand(Guid Id) : IRequest;
