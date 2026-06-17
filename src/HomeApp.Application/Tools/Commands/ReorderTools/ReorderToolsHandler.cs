using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Tools.Commands;

public class ReorderToolsHandler(IAppDbContext dbContext) : IRequestHandler<ReorderToolsCommand>
{
    public async Task Handle(ReorderToolsCommand request, CancellationToken cancellationToken)
    {
        List<Tool> tools = await dbContext.Tools
            .Where(t => request.OrderedIds.Contains(t.Id))
            .ToListAsync(cancellationToken);

        for (int i = 0; i < request.OrderedIds.Count; i++)
        {
            Tool? tool = tools.FirstOrDefault(t => t.Id == request.OrderedIds[i]);
            if (tool is not null)
                tool.SortOrder = i;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
