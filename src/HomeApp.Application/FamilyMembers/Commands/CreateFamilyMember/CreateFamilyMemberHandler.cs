using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.FamilyMembers.Commands;

public class CreateFamilyMemberHandler(IAppDbContext dbContext) : IRequestHandler<CreateFamilyMemberCommand, Guid>
{
    public async Task<Guid> Handle(CreateFamilyMemberCommand request, CancellationToken cancellationToken)
    {
        var member = new FamilyMember
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Birthday = request.Birthday,
            PhoneNumber = request.PhoneNumber
        };

        dbContext.FamilyMembers.Add(member);
        await dbContext.SaveChangesAsync(cancellationToken);
        return member.Id;
    }
}
