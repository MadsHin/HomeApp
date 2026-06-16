using MediatR;

namespace HomeApp.Application.FamilyMembers.Commands;

public record DeleteFamilyMemberCommand(Guid Id) : IRequest;
