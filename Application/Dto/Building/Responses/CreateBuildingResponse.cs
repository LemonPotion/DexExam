namespace Application.Dto.Building.Responses;

public record CreateBuildingResponse(
    Guid Id,
    string Address,
    string? Name,
    string? Description);