using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Materials.Queries;

public class GetShoppingListHandler(IAppDbContext dbContext) : IRequestHandler<GetShoppingListQuery, List<ShoppingListItemDto>>
{
    public async Task<List<ShoppingListItemDto>> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
    {
        var rows = await dbContext.HomeProjectMaterials
            .Where(hpm => hpm.QuantityNeeded.HasValue && hpm.QuantityNeeded > 0)
            .Join(dbContext.Materials, hpm => hpm.MaterialId, m => m.Id,
                (hpm, m) => new { hpm, m })
            .Join(dbContext.HomeProjects, x => x.hpm.HomeProjectId, p => p.Id,
                (x, p) => new
                {
                    x.m.Id,
                    x.m.Name,
                    x.m.Unit,
                    x.m.Quantity,
                    x.m.UnitPrice,
                    QuantityNeeded = x.hpm.QuantityNeeded!.Value,
                    ProjectTitle = p.Title
                })
            .ToListAsync(cancellationToken);

        return rows
            .GroupBy(x => new { x.Id, x.Name, x.Unit, x.Quantity, x.UnitPrice })
            .Select(g =>
            {
                decimal totalNeeded = g.Sum(x => x.QuantityNeeded);
                decimal shortfall = Math.Max(0, totalNeeded - (g.Key.Quantity ?? 0));
                decimal? estimatedCost = g.Key.UnitPrice.HasValue ? shortfall * g.Key.UnitPrice.Value : null;
                return new ShoppingListItemDto(
                    g.Key.Id,
                    g.Key.Name,
                    g.Key.Unit,
                    totalNeeded,
                    g.Key.Quantity,
                    shortfall,
                    g.Select(x => x.ProjectTitle).Distinct().OrderBy(t => t).ToList(),
                    estimatedCost
                );
            })
            .Where(x => x.Shortfall > 0)
            .OrderByDescending(x => x.Shortfall)
            .ToList();
    }
}
