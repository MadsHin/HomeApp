using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Tools.Commands;

public class UpdateToolHandler(IAppDbContext dbContext) : IRequestHandler<UpdateToolCommand>
{
    public async Task Handle(UpdateToolCommand request, CancellationToken cancellationToken)
    {
        var tool = await dbContext.Tools.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (tool is null) return;

        tool.Name = request.Name;
        tool.Category = request.Category;
        tool.Icon = request.Icon;
        tool.Notes = request.Notes;
        tool.Status = request.Status;
        tool.StatusNote = request.StatusNote;
        tool.StorageLocationId = request.StorageLocationId;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
