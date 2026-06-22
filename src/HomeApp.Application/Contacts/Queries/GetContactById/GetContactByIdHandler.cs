using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Contacts.Queries;

public class GetContactByIdHandler(IAppDbContext dbContext) : IRequestHandler<GetContactByIdQuery, ContactDto?>
{
    public async Task<ContactDto?> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Contacts
            .Where(c => c.Id == request.Id)
            .Select(c => new ContactDto(c.Id, c.Name, c.Phone, c.JobTitle, c.Notes))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
