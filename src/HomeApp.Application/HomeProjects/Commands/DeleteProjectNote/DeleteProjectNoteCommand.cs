using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record DeleteProjectNoteCommand(Guid Id) : IRequest;
