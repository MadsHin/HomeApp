using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record AddPhotoCommand(
    Guid HomeProjectId,
    string FileName,
    string StoredFileName,
    string? Caption
) : IRequest;
