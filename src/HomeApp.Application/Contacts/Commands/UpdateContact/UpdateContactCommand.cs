using MediatR;

namespace HomeApp.Application.Contacts.Commands;

public record UpdateContactCommand(
    Guid Id,
    string Name,
    string? Phone
) : IRequest;
