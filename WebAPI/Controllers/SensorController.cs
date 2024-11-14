using Application.Dto.Sensor.Requests;
using Application.Dto.Sensor.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : ControllerBase
{
    private readonly SensorService _sensorService;

    public SensorController(SensorService sensorService)
    {
        _sensorService = sensorService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateSensorRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _sensorService.CreateAsync(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] UpdateSensorRequest request, CancellationToken cancellationToken)
    {
        var response = _sensorService.UpdateAsync(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _sensorService.GetByIdAsync(id, cancellationToken);
        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetSensorResponse>>> GetAllAsync([FromQuery] int pageNumber,
        [FromQuery] int pageSize, CancellationToken cancellationToken)
    {
        var response = await _sensorService.GetAllAsync(pageNumber, pageSize, null, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        await _sensorService.RemoveAsync(id, cancellationToken);
        return NoContent();
    }
}