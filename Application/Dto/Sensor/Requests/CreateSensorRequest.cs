namespace Application.Dto.Sensor.Requests;

public record CreateSensorRequest(
    Guid BuildingId,
    Guid UserId,
    decimal XCoord,
    decimal YCoord,
    string? Description,
    string? ImageFilePath);