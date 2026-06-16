using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class AddProjectLinkHandler(IAppDbContext dbContext) : IRequestHandler<AddProjectLinkCommand, Guid>
{
    public async Task<Guid> Handle(AddProjectLinkCommand request, CancellationToken cancellationToken)
    {
        var link = new ProjectLink
        {
            Id = Guid.NewGuid(),
            HomeProjectId = request.HomeProjectId,
            HomeProject = null!,
            Label = request.Label,
            Url = request.Url
        };

        dbContext.ProjectLinks.Add(link);
        await dbContext.SaveChangesAsync(cancellationToken);
        return link.Id;
    }
}
