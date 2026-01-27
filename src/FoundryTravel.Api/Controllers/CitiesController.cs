using FoundryTravel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoundryTravel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ICityService _cityService;

    public CitiesController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cities = await _cityService.GetAllAsync();
        return Ok(cities);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var city = await _cityService.GetByIdAsync(id);
        return city is null ? NotFound() : Ok(city);
    }
}