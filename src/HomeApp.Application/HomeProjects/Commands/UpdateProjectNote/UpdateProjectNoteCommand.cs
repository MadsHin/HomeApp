using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record UpdateProjectNoteCommand(
    Guid Id,
    string Content,
    List<Guid> PhotoIds
) : IRequest;
