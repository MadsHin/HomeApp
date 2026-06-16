using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Materials.Queries;

public class GetMaterialsHandler(IAppDbContext dbContext) : IRequestHandler<GetMaterialsQuery, List<MaterialDto>>
{
    public async Task<List<MaterialDto>> Handle(GetMaterialsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Materials
            .Select(m => new MaterialDto(m.Id, m.Name, m.Quantity, m.Unit, m.Location, m.Notes, m.Icon))
            .ToListAsync(cancellationToken);
    }
}
