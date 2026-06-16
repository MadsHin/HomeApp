using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.FamilyMembers.Queries;

public class GetFamilyMemberByIdHandler(IAppDbContext dbContext) : IRequestHandler<GetFamilyMemberByIdQuery, FamilyMemberDto?>
{
    public async Task<FamilyMemberDto?> Handle(GetFamilyMemberByIdQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.FamilyMembers
            .Where(m => m.Id == request.Id)
            .Select(m => new FamilyMemberDto(m.Id, m.Name, m.Age, m.PhoneNumber))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
