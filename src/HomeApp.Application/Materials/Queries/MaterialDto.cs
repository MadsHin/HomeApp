namespace HomeApp.Application.Materials.Queries;

public record MaterialDto(
    Guid Id,
    string Name,
    decimal? Quantity,
    string? Unit,
    Guid? StorageLocationId,
    string? StorageLocationName,
    string? Notes,
    string? Icon
);
