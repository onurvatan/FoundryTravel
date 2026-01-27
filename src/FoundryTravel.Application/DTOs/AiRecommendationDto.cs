using System.Text.Json;

namespace FoundryTravel.Application.DTOs;

public record AiRecommendationDto(
    string RecommendedHotelName,
    string Reason
)
{
    public static AiRecommendationDto FromJson(string json)
    {
        return JsonSerializer.Deserialize<AiRecommendationDto>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        )!;
    }
}