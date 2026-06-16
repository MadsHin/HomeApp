using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.Contacts.Commands;

public class DeleteContactHandler(IAppDbContext dbContext) : IRequestHandler<DeleteContactCommand>
{
    public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await dbContext.Contacts.FindAsync([request.Id], cancellationToken);

        if (contact is null)
            return;

        dbContext.Contacts.Remove(contact);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
