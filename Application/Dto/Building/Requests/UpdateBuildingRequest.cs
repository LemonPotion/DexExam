namespace Application.Dto.Building.Requests;

public record UpdateBuildingRequest(
    Guid Id,
    string Address,
    string? Name,
    string? Description);