using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Materials.Queries;

public class GetMaterialsHandler(IAppDbContext dbContext) : IRequestHandler<GetMaterialsQuery, List<MaterialDto>>
{
    public async Task<List<MaterialDto>> Handle(GetMaterialsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Materials
            .OrderBy(m => m.SortOrder)
            .ThenByDescending(m => m.CreatedAt)
            .Select(m => new MaterialDto(
                m.Id, m.Name, m.Quantity, m.Unit,
                m.StorageLocationId,
                m.StorageLocation != null ? m.StorageLocation.Name : null,
                m.Notes, m.Icon, m.UnitPrice))
            .ToListAsync(cancellationToken);
    }
}
