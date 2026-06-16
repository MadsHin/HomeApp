using MediatR;

namespace HomeApp.Application.FamilyMembers.Queries;

public record GetFamilyMembersQuery() : IRequest<List<FamilyMemberDto>>;
