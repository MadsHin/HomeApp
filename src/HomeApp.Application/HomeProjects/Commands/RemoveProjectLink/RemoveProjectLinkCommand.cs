using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record RemoveProjectLinkCommand(Guid Id) : IRequest;
