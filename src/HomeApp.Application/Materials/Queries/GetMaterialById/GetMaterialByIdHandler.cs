using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Materials.Queries;

public class GetMaterialByIdHandler(IAppDbContext dbContext) : IRequestHandler<GetMaterialByIdQuery, MaterialDto?>
{
    public async Task<MaterialDto?> Handle(GetMaterialByIdQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Materials
            .Where(m => m.Id == request.Id)
            .Select(m => new MaterialDto(m.Id, m.Name, m.Quantity, m.Unit, m.Location, m.Notes, m.Icon))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
