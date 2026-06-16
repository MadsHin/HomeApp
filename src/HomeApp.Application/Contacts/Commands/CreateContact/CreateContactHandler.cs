using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.Contacts.Commands;

public class CreateContactHandler(IAppDbContext dbContext) : IRequestHandler<CreateContactCommand, Guid>
{
    public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Phone = request.Phone
        };

        dbContext.Contacts.Add(contact);
        await dbContext.SaveChangesAsync(cancellationToken);
        return contact.Id;
    }
}
