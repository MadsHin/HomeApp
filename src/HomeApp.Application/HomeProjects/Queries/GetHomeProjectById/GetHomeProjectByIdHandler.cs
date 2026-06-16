using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetHomeProjectByIdHandler(IAppDbContext dbContext) : IRequestHandler<GetHomeProjectByIdQuery, HomeProjectDto?>
{
    public async Task<HomeProjectDto?> Handle(GetHomeProjectByIdQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.HomeProjects
            .Where(p => p.Id == request.Id)
            .Select(p => new HomeProjectDto(p.Id, p.Title, p.Description, p.Status, p.Budget, p.StartDate, p.CompletedDate))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
