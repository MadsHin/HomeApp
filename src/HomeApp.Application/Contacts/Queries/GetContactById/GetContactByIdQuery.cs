using MediatR;

namespace HomeApp.Application.Contacts.Queries;

public record GetContactByIdQuery(Guid Id) : IRequest<ContactDto?>;
