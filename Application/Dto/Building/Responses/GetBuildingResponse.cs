namespace Application.Dto.Building.Responses;

public record GetBuildingResponse(
    Guid Id,
    string Address,
    string? Name,
    string? Description);