namespace Application.Dto.Building.Requests;

public record CreateBuildingRequest(
    string Address,
    string? Name,
    string? Description);