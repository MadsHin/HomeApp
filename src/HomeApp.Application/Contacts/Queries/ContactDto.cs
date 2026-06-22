namespace HomeApp.Application.Contacts.Queries;

public record ContactDto(
    Guid Id,
    string Name,
    string? Phone,
    string? JobTitle,
    string? Notes
);
