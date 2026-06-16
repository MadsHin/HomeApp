using MediatR;

namespace HomeApp.Application.Contacts.Commands;

public record DeleteContactCommand(Guid Id) : IRequest;
