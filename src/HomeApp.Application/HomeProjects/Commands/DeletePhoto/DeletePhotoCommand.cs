using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record DeletePhotoCommand(Guid Id) : IRequest<string?>;
