using System.Linq.Expressions;
using Application.Dto.Building.Requests;
using Application.Dto.Building.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class BuildingService
{
    private readonly IRepository<Building> _buildingRepository;

    private readonly IMapper _mapper;

    public BuildingService(IRepository<Building> buildingRepository, IMapper mapper)
    {
        _buildingRepository = buildingRepository;
        _mapper = mapper;
    }

    public async Task<CreateBuildingResponse> CreateAsync(CreateBuildingRequest request,
        CancellationToken cancellationToken)
    {
        var building = _mapper.Map<Building>(request);
        var createdBuilding = await _buildingRepository.AddAsync(building, cancellationToken);
        await _buildingRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CreateBuildingResponse>(createdBuilding);
    }

    public async Task<UpdateBuildingResponse> UpdateAsync(UpdateBuildingRequest request, CancellationToken cancellationToken)
    {
        var building = _mapper.Map<Building>(request);
        var updatedBuilding = _buildingRepository.Update(building);
        await _buildingRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UpdateBuildingResponse>(updatedBuilding);
    }

    public async Task<GetBuildingResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var building = await _buildingRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<GetBuildingResponse>(building);
    }

    public async Task<List<GetBuildingResponse>> GetAllAsync(int pageNumber, int pageSize,
        Expression<Func<Building, bool>>? filter, CancellationToken cancellationToken)
    {
        var buildings = await _buildingRepository.GetAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<GetBuildingResponse>>(buildings);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        await _buildingRepository.RemoveAsync(id, cancellationToken);
        await _buildingRepository.SaveChangesAsync(cancellationToken);
    }
}