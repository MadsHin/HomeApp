namespace HomeApp.Application.HomeProjects.Queries;

public record ProjectMaterialDto(
    Guid MaterialId,
    string Name,
    string? Icon,
    string? Unit,
    decimal? QuantityNeeded,
    decimal? QuantityInStock
);
