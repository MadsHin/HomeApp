using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Contacts.Queries;

public class GetContactsHandler(IAppDbContext dbContext) : IRequestHandler<GetContactsQuery, List<ContactDto>>
{
    public async Task<List<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Contacts
            .Select(c => new ContactDto(c.Id, c.Name, c.Phone))
            .ToListAsync(cancellationToken);
    }
}
