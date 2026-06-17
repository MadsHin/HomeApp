using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Tools.Commands;

public class CreateToolHandler(IAppDbContext dbContext) : IRequestHandler<CreateToolCommand, Guid>
{
    public async Task<Guid> Handle(CreateToolCommand request, CancellationToken cancellationToken)
    {
        int count = await dbContext.Tools.CountAsync(cancellationToken);

        Tool tool = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Category = request.Category,
            Icon = request.Icon,
            Notes = request.Notes,
            Status = request.Status,
            StatusNote = request.StatusNote,
            SortOrder = count,
            CreatedAt = DateTime.UtcNow
        };

        dbContext.Tools.Add(tool);
        await dbContext.SaveChangesAsync(cancellationToken);
        return tool.Id;
    }
}
