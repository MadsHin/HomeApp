using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class DeleteHomeProjectHandler(IAppDbContext dbContext) : IRequestHandler<DeleteHomeProjectCommand>
{
    public async Task Handle(DeleteHomeProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await dbContext.HomeProjects.FindAsync([request.Id], cancellationToken);

        if (project is null)
            return;

        dbContext.HomeProjects.Remove(project);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
