using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class AddToolToProjectHandler(IAppDbContext dbContext) : IRequestHandler<AddToolToProjectCommand>
{
    public async Task Handle(AddToolToProjectCommand request, CancellationToken cancellationToken)
    {
        dbContext.HomeProjectTools.Add(new HomeProjectTool
        {
            HomeProjectId = request.HomeProjectId,
            ToolId = request.ToolId
        });
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
