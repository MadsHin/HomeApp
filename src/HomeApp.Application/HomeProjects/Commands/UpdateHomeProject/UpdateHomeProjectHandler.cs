using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class UpdateHomeProjectHandler(IAppDbContext dbContext) : IRequestHandler<UpdateHomeProjectCommand>
{
    public async Task Handle(UpdateHomeProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await dbContext.HomeProjects.FindAsync([request.Id], cancellationToken);

        if (project is null)
            return;

        project.Title = request.Title;
        project.Description = request.Description;
        project.Budget = request.Budget;
        project.StartDate = request.StartDate;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
