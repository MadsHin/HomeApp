using MediatR;

namespace HomeApp.Application.Contacts.Commands;

public record CreateContactCommand(
    string Name,
    string? Phone
) : IRequest<Guid>;
