using FoundryTravel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoundryTravel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelsController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] Guid cityId,
        [FromQuery] decimal? maxPrice,
        [FromQuery] int? starRating,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize= 20)
    {
        var hotels = await _hotelService.SearchAsync(cityId, maxPrice, starRating, page, pageSize);

        return Ok(hotels);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var hotel = await _hotelService.GetByIdAsync(id);

        return hotel is null ? NotFound() : Ok(hotel);
    }
}