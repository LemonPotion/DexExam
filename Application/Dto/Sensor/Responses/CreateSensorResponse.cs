namespace Application.Dto.Sensor.Responses;

public record CreateSensorResponse(
    Guid Id,
    Guid BuildingId,
    Guid UserId,
    decimal XCoord,
    decimal YCoord,
    string? Description,
    string? ImageFilePath);