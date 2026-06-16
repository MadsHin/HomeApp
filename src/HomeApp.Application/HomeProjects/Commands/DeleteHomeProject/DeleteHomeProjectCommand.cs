using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record DeleteHomeProjectCommand(Guid Id) : IRequest;
