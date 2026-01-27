using System.Text.Json;

namespace FoundryTravel.Application.DTOs;

public record AiSearchResultDto(
    string? CityName,
    decimal? MaxPrice,
    int? StarRating
)
{
    public static AiSearchResultDto FromJson(string json)
    {
        return JsonSerializer.Deserialize<AiSearchResultDto>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        )!;
    }
}