using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class RemoveProjectLinkHandler(IAppDbContext dbContext) : IRequestHandler<RemoveProjectLinkCommand>
{
    public async Task Handle(RemoveProjectLinkCommand request, CancellationToken cancellationToken)
    {
        var link = await dbContext.ProjectLinks.FindAsync([request.Id], cancellationToken);

        if (link is null)
            return;

        dbContext.ProjectLinks.Remove(link);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
