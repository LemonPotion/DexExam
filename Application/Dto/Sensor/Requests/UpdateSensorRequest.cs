namespace Application.Dto.Sensor.Requests;

public record UpdateSensorRequest(
    Guid Id,
    Guid BuildingId,
    Guid UserId,
    decimal XCoord,
    decimal YCoord,
    string? Description,
    string? ImageFilePath);