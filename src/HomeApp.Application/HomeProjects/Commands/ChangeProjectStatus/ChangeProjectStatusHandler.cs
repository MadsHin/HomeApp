using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class ChangeProjectStatusHandler(IAppDbContext dbContext) : IRequestHandler<ChangeProjectStatusCommand>
{
    public async Task Handle(ChangeProjectStatusCommand request, CancellationToken cancellationToken)
    {
        var project = await dbContext.HomeProjects.FindAsync([request.Id], cancellationToken);

        if (project is null)
            return;

        project.Status = request.Status;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
