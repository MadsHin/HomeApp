using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record ToggleTimelineEventCompletionCommand(Guid Id) : IRequest;
