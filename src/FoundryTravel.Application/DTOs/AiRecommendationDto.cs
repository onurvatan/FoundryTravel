using System.Text.Json;

namespace FoundryTravel.Application.DTOs;

public record AiRecommendationDto(
    Guid HotelId,
    string RecommendedHotelName,
    string Reason
)
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static AiRecommendationDto FromJson(string json)
    {
        var cleanedJson = ExtractJson(json);

        try
        {
            // Handle array response - take first element
            if (cleanedJson.TrimStart().StartsWith('['))
            {
                var array = JsonSerializer.Deserialize<AiRecommendationDto[]>(cleanedJson, JsonOptions);
                return array?.FirstOrDefault()
                    ?? throw new JsonException("Empty array returned.");
            }

            return JsonSerializer.Deserialize<AiRecommendationDto>(cleanedJson, JsonOptions)
                ?? throw new JsonException("Deserialization returned null.");
        }
        catch (JsonException ex)
        {
            throw new JsonException($"Failed to parse AI response. Cleaned JSON: '{cleanedJson}'. Original: '{json}'", ex);
        }
    }

    private static string ExtractJson(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "{}";

        var text = input.Trim();

        // Strip markdown code block if present (handles ```json or just ```)
        if (text.StartsWith("```"))
        {
            var firstNewline = text.IndexOf('\n');
            if (firstNewline >= 0)
                text = text[(firstNewline + 1)..];

            var lastFence = text.LastIndexOf("```");
            if (lastFence >= 0)
                text = text[..lastFence];

            text = text.Trim();
        }

        // Find the JSON array boundaries first
        var arrayStart = text.IndexOf('[');
        var arrayEnd = text.LastIndexOf(']');

        // Find the JSON object boundaries
        var objectStart = text.IndexOf('{');
        var objectEnd = text.LastIndexOf('}');

        // If array starts before object, use array boundaries
        if (arrayStart >= 0 && arrayEnd > arrayStart && 
            (objectStart < 0 || arrayStart < objectStart))
        {
            return text[arrayStart..(arrayEnd + 1)];
        }

        if (objectStart >= 0 && objectEnd > objectStart)
            return text[objectStart..(objectEnd + 1)];

        return text;
    }
}