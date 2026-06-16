using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class RemoveContactFromProjectHandler(IAppDbContext dbContext) : IRequestHandler<RemoveContactFromProjectCommand>
{
    public async Task Handle(RemoveContactFromProjectCommand request, CancellationToken cancellationToken)
    {
        var join = await dbContext.HomeProjectContacts
            .FirstOrDefaultAsync(c => c.HomeProjectId == request.HomeProjectId && c.ContactId == request.ContactId, cancellationToken);

        if (join is null)
            return;

        dbContext.HomeProjectContacts.Remove(join);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
