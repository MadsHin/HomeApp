using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.Contacts.Commands;

public class UpdateContactHandler(IAppDbContext dbContext) : IRequestHandler<UpdateContactCommand>
{
    public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await dbContext.Contacts.FindAsync([request.Id], cancellationToken);

        if (contact is null)
            return;

        contact.Name = request.Name;
        contact.Phone = request.Phone;
        contact.JobTitle = request.JobTitle;
        contact.Notes = request.Notes;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
