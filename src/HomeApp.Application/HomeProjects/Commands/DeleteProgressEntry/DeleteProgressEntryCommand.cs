using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record DeleteProgressEntryCommand(Guid Id) : IRequest;
