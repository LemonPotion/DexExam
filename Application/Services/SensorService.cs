using System.Linq.Expressions;
using Application.Dto.Sensor.Requests;
using Application.Dto.Sensor.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class SensorService
{
    private readonly IRepository<Sensor> _sensorRepository;

    private readonly IMapper _mapper;

    public SensorService(IRepository<Sensor> sensorRepository, IMapper mapper)
    {
        _sensorRepository = sensorRepository;
        _mapper = mapper;
    }

    public async Task<CreateSensorResponse> CreateAsync(CreateSensorRequest request,
        CancellationToken cancellationToken)
    {
        var sensor = _mapper.Map<Sensor>(request);
        var createdSensor = await _sensorRepository.AddAsync(sensor, cancellationToken);
        await _sensorRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CreateSensorResponse>(createdSensor);
    }

    public async Task<UpdateSensorResponse> UpdateAsync(UpdateSensorRequest request, CancellationToken cancellationToken)
    {
        var sensor = _mapper.Map<Sensor>(request);
        var updatedSensor = _sensorRepository.Update(sensor);
        await _sensorRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UpdateSensorResponse>(updatedSensor);
    }

    public async Task<GetSensorResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var sensor = await _sensorRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<GetSensorResponse>(sensor);
    }

    public async Task<List<GetSensorResponse>> GetAllAsync(int pageNumber, int pageSize,
        Expression<Func<Sensor, bool>>? filter, CancellationToken cancellationToken)
    {
        var sensorList = await _sensorRepository.GetAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<GetSensorResponse>>(sensorList);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        await _sensorRepository.RemoveAsync(id, cancellationToken);
        await _sensorRepository.SaveChangesAsync(cancellationToken);
    }
}