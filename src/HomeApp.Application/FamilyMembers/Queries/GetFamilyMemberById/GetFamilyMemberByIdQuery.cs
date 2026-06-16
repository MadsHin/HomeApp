using MediatR;

namespace HomeApp.Application.FamilyMembers.Queries;

public record GetFamilyMemberByIdQuery(Guid Id) : IRequest<FamilyMemberDto?>;
