using MediatR;

namespace HomeApp.Application.FamilyMembers.Commands;

public record UpdateFamilyMemberCommand(
    Guid Id,
    string Name,
    int Age,
    string? PhoneNumber
) : IRequest;
