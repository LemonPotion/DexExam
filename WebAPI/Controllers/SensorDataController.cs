using Application.Dto.SensorData.Requests;
using Application.Dto.SensorData.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorDataController : ControllerBase
{
    private readonly SensorDataService _sensorDataService;

    public SensorDataController(SensorDataService sensorDataService)
    {
        _sensorDataService = sensorDataService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateSensorDataRequest request, CancellationToken cancellationToken)
    {
        var response = await _sensorDataService.CreateAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public IActionResult Update([FromBody] UpdateSensorDataRequest request, CancellationToken cancellationToken)
    {
        var response = _sensorDataService.UpdateAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _sensorDataService.GetByIdAsync(id, cancellationToken);
        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetSensorDataResponse>>> GetAllAsync([FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken cancellationToken)
    {
        var response = await _sensorDataService.GetAllAsync(pageNumber, pageSize, null, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        await _sensorDataService.RemoveAsync(id, cancellationToken);
        return NoContent();
    }
}