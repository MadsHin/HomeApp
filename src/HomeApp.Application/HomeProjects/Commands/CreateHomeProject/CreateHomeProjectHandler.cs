using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class CreateHomeProjectHandler(IAppDbContext dbContext) : IRequestHandler<CreateHomeProjectCommand, Guid>
{
    public async Task<Guid> Handle(CreateHomeProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new HomeProject
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Status = request.Status,
            Budget = request.Budget,
            StartDate = request.StartDate
        };

        dbContext.HomeProjects.Add(project);
        await dbContext.SaveChangesAsync(cancellationToken);
        return project.Id;
    }
}
