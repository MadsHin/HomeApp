using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class RemoveToolFromProjectHandler(IAppDbContext dbContext) : IRequestHandler<RemoveToolFromProjectCommand>
{
    public async Task Handle(RemoveToolFromProjectCommand request, CancellationToken cancellationToken)
    {
        var entry = await dbContext.HomeProjectTools
            .FirstOrDefaultAsync(pt => pt.HomeProjectId == request.HomeProjectId && pt.ToolId == request.ToolId,
                cancellationToken);

        if (entry is null) return;

        dbContext.HomeProjectTools.Remove(entry);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
