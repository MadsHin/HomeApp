using MediatR;

namespace HomeApp.Application.Contacts.Queries;

public record GetContactsQuery() : IRequest<List<ContactDto>>;
