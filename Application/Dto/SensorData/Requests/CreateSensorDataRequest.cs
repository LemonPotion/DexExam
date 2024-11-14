namespace Application.Dto.SensorData.Requests;

public record CreateSensorDataRequest(
    int Temperature,
    int Humidity,
    int Charge,
    Guid SensorId);