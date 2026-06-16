using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetHomeProjectsHandler(IAppDbContext dbContext) : IRequestHandler<GetHomeProjectsQuery, List<HomeProjectDto>>
{
    public async Task<List<HomeProjectDto>> Handle(GetHomeProjectsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.HomeProjects
            .Select(p => new HomeProjectDto(p.Id, p.Title, p.Description, p.Status, p.Budget, p.StartDate, p.CompletedDate))
            .ToListAsync(cancellationToken);
    }
}
