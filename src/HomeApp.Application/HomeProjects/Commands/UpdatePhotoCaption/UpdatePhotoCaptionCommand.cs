using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record UpdatePhotoCaptionCommand(Guid Id, string? Caption) : IRequest;
