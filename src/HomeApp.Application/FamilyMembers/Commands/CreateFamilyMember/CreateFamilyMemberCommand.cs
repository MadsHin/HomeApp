using MediatR;

namespace HomeApp.Application.FamilyMembers.Commands;

public record CreateFamilyMemberCommand(
    string Name,
    DateOnly? Birthday,
    string? PhoneNumber
) : IRequest<Guid>;
