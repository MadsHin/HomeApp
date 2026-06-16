namespace HomeApp.Application.Materials.Queries;

public record MaterialDto(
    Guid Id,
    string Name,
    decimal? Quantity,
    string? Unit,
    string? Location,
    string? Notes,
    string? Icon
);
