using MediatR;

namespace HomeApp.Application.Contacts.Commands;

public record CreateContactCommand(
    string Name,
    string? Phone,
    string? JobTitle,
    string? Notes
) : IRequest<Guid>;
