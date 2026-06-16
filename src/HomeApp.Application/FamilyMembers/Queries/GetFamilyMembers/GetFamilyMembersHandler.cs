using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.FamilyMembers.Queries;

public class GetFamilyMembersHandler(IAppDbContext dbContext) : IRequestHandler<GetFamilyMembersQuery, List<FamilyMemberDto>>
{
    public async Task<List<FamilyMemberDto>> Handle(GetFamilyMembersQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.FamilyMembers
            .Select(m => new FamilyMemberDto(m.Id, m.Name, m.Age, m.PhoneNumber))
            .ToListAsync(cancellationToken);
    }
}
