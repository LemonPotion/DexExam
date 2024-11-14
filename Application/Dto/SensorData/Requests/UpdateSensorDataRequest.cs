namespace Application.Dto.SensorData.Requests;

public record UpdateSensorDataRequest(
    Guid Id,
    int Temperature,
    int Humidity,
    int Charge,
    Guid SensorId);