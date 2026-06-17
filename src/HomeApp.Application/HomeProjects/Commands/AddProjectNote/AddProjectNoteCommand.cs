using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record AddProjectNoteCommand(
    Guid HomeProjectId,
    string Content,
    List<Guid> PhotoIds
) : IRequest;
