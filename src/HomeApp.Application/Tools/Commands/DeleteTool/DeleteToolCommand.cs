using MediatR;

namespace HomeApp.Application.Tools.Commands;

public record DeleteToolCommand(Guid Id) : IRequest;
