using System.Text.Json;

namespace FoundryTravel.Application.DTOs;

public record AiSearchResultDto(
    Guid? HotelId,
    string? CityName,
    decimal? MaxPrice,
    int? StarRating
)
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static AiSearchResultDto FromJson(string json)
    {
        var cleanedJson = StripMarkdownCodeBlock(json.AsSpan());
        return JsonSerializer.Deserialize<AiSearchResultDto>(cleanedJson, JsonOptions)!;
    }

    private static string StripMarkdownCodeBlock(ReadOnlySpan<char> input)
    {
        var trimmed = input.Trim();

        if (!trimmed.StartsWith("```"))
            return trimmed.ToString();

        var firstNewline = trimmed.IndexOf('\n');
        if (firstNewline >= 0)
            trimmed = trimmed[(firstNewline + 1)..];

        if (trimmed.EndsWith("```"))
            trimmed = trimmed[..^3];

        return trimmed.Trim().ToString();
    }
}