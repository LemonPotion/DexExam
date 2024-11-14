using Application.Dto.Building.Requests;
using Application.Dto.Building.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildingController : ControllerBase
{
    private readonly BuildingService _buildingService;

    public BuildingController(BuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateBuildingRequest request, CancellationToken cancellationToken)
    {
        var response = await _buildingService.CreateAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public IActionResult Update([FromBody] UpdateBuildingRequest request, CancellationToken cancellationToken)
    {
        var response = _buildingService.UpdateAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _buildingService.GetByIdAsync(id, cancellationToken);
        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetBuildingResponse>>> GetAllAsync([FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken cancellationToken)
    {
        var response = await _buildingService.GetAllAsync(pageNumber, pageSize, null, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        await _buildingService.RemoveAsync(id, cancellationToken);
        return NoContent();
    }
}