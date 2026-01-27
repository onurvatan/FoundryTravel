using Azure;
using Azure.AI.OpenAI;
using FoundryTravel.Application.DTOs;
using FoundryTravel.Application.Interfaces;
using FoundryTravel.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;

namespace FoundryTravel.Application.Services;

public class AiService : IAiService
{
    private readonly ChatClient _chatClient;
    private readonly IHotelRepository _hotelRepository;

    public AiService(
        IConfiguration config,
        IHotelRepository hotelRepository)
    {
        var azureClient = new AzureOpenAIClient(
            new Uri(config["AzureAI:Endpoint"]!),
            new AzureKeyCredential(config["AzureAI:ApiKey"]!)
        );

        _chatClient = azureClient.GetChatClient(config["AzureAI:Deployment"]!);
        _hotelRepository = hotelRepository;
    }

    public async Task<AiSearchResultDto> NaturalLanguageSearchAsync(string query)
    {
        ChatCompletion completion = await _chatClient.CompleteChatAsync(
        [
            new UserChatMessage($@"
Convert the following hotel search query into structured filters.

User query: {query}

Return ONLY valid JSON with:
- cityName (string or null)
- maxPrice (number or null)
- starRating (number or null)
")
        ]);

        string content = completion.Content[0].Text;

        return AiSearchResultDto.FromJson(content);
    }

    public async Task<AiRecommendationDto> RecommendHotelsAsync(string preferences)
    {
        var (hotels, _) = await _hotelRepository.SearchAsync(
            cityId: Guid.Empty,
            maxPrice: null,
            starRating: null,
            page: 1,
            pageSize: 10
        );

        var hotelList = string.Join("\n", hotels.Select(h =>
            $"{h.Name} | {h.Description} | {h.StarRating} stars | {h.BasePricePerNight} EUR"
        ));

        ChatCompletion completion = await _chatClient.CompleteChatAsync(
        [
            new UserChatMessage($@"
You are a hotel recommendation engine.

User preferences:
{preferences}

Hotels:
{hotelList}

Return ONLY JSON with:
- recommendedHotelName
- reason
")
        ]);

        string content = completion.Content[0].Text;

        return AiRecommendationDto.FromJson(content);
    }

    public async Task<string> AnswerHotelFaqAsync(Guid hotelId, string question)
    {
        var hotel = await _hotelRepository.GetByIdAsync(hotelId);
        if (hotel == null)
            return "Hotel not found.";

        ChatCompletion completion = await _chatClient.CompleteChatAsync(
        [
            new UserChatMessage($@"
You are a hotel FAQ assistant.

Hotel details:
Name: {hotel.Name}
Description: {hotel.Description}
Stars: {hotel.StarRating}
Price: {hotel.BasePricePerNight}
Address: {hotel.Address}

User question: {question}

Answer concisely.
")
        ]);

        return completion.Content[0].Text;
    }
}