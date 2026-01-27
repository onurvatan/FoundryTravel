using FoundryTravel.Application.DTOs;

namespace FoundryTravel.Application.Interfaces;

public interface IAiService
{
    Task<AiSearchResultDto> NaturalLanguageSearchAsync(string query);
    Task<AiRecommendationDto> RecommendHotelsAsync(string preferences);
    Task<string> AnswerHotelFaqAsync(Guid hotelId, string question);
}