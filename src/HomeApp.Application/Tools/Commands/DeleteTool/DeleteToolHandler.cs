using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Tools.Commands;

public class DeleteToolHandler(IAppDbContext dbContext) : IRequestHandler<DeleteToolCommand>
{
    public async Task Handle(DeleteToolCommand request, CancellationToken cancellationToken)
    {
        var tool = await dbContext.Tools.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (tool is null) return;

        dbContext.Tools.Remove(tool);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
