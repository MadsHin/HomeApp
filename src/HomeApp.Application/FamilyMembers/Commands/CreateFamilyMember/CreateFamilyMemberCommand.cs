using MediatR;

namespace HomeApp.Application.FamilyMembers.Commands;

public record CreateFamilyMemberCommand(
    string Name,
    int Age,
    string? PhoneNumber
) : IRequest<Guid>;
