namespace Application.Dto.Building.Responses;

public record UpdateBuildingResponse(
    Guid Id,
    string Address,
    string? Name,
    string? Description);