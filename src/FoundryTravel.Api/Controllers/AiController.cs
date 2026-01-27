using FoundryTravel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoundryTravel.Api.Controllers;

[ApiController]
[Route("api/ai")]
public class AiController(IAiService aiService) : ControllerBase
{
    private readonly IAiService _aiService = aiService;

    [HttpPost("search")]
    public async Task<IActionResult> NaturalLanguageSearch([FromBody] string query)
        => Ok(await _aiService.NaturalLanguageSearchAsync(query));

    [HttpPost("recommend")]
    public async Task<IActionResult> Recommend([FromBody] string preferences)
        => Ok(await _aiService.RecommendHotelsAsync(preferences));

    [HttpPost("faq/{hotelId}")]
    public async Task<IActionResult> Faq(Guid hotelId, [FromBody] string question)
        => Ok(await _aiService.AnswerHotelFaqAsync(hotelId, question));
}