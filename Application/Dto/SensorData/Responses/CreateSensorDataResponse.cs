namespace Application.Dto.SensorData.Responses;

public record CreateSensorDataResponse(
    Guid Id,
    int Temperature,
    int Humidity,
    int Charge,
    DateTime CreateDate,
    Guid SensorId);