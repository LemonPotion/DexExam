using System.Linq.Expressions;
using Application.Dto.SensorData.Requests;
using Application.Dto.SensorData.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class SensorDataService
{
    private readonly IRepository<SensorData> _sensorDataRepository;

    private readonly IMapper _mapper;

    public SensorDataService(IRepository<SensorData> sensorDataRepository, IMapper mapper)
    {
        _sensorDataRepository = sensorDataRepository;
        _mapper = mapper;
    }

    public async Task<CreateSensorDataResponse> CreateAsync(CreateSensorDataRequest request,
        CancellationToken cancellationToken)
    {
        var sensorData = _mapper.Map<SensorData>(request);
        var createdSensorData = await _sensorDataRepository.AddAsync(sensorData, cancellationToken);
        await _sensorDataRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CreateSensorDataResponse>(createdSensorData);
    }

    public async Task<UpdateSensorDataResponse> UpdateAsync(UpdateSensorDataRequest request, CancellationToken cancellationToken)
    {
        var sensorData = _mapper.Map<SensorData>(request);
        var updatedSensorData = _sensorDataRepository.Update(sensorData);
        await _sensorDataRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UpdateSensorDataResponse>(updatedSensorData);
    }

    public async Task<GetSensorDataResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var sensorData = await _sensorDataRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<GetSensorDataResponse>(sensorData);
    }

    public async Task<List<GetSensorDataResponse>> GetAllAsync(int pageNumber, int pageSize,
        Expression<Func<SensorData, bool>>? filter, CancellationToken cancellationToken)
    {
        var sensorDataList = await _sensorDataRepository.GetAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<GetSensorDataResponse>>(sensorDataList);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        await _sensorDataRepository.RemoveAsync(id, cancellationToken);
        await _sensorDataRepository.SaveChangesAsync(cancellationToken);
    }
}