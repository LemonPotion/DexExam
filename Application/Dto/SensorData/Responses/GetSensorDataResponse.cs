namespace Application.Dto.SensorData.Responses;

public record GetSensorDataResponse(
    Guid Id,
    int Temperature,
    int Humidity,
    int Charge,
    DateTime CreateDate,
    Guid SensorId);