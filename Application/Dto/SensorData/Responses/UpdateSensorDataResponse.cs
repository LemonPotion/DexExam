namespace Application.Dto.SensorData.Responses;

public record UpdateSensorDataResponse(
    Guid Id,
    int Temperature,
    int Humidity,
    int Charge,
    DateTime CreateDate,
    Guid SensorId);