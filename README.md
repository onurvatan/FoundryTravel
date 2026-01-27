# FoundryTravel

A .NET 10 Travel API with AI-powered hotel search and recommendations using Azure OpenAI.

## Features

- **Hotel Search** – Search hotels by city, price, and star rating with pagination
- **AI Natural Language Search** – Convert natural language queries into structured hotel filters
- **AI Hotel Recommendations** – Get personalized hotel recommendations based on preferences
- **Hotel FAQ Assistant** – Ask questions about specific hotels and get AI-powered answers

## Tech Stack

- **.NET 10** – ASP.NET Core Web API
- **Azure OpenAI** – GPT-4o-mini for AI features
- **Entity Framework Core** – Data access with in-memory database for development
- **Serilog** – Structured logging
- **Swagger/OpenAPI** – API documentation

## Project Structure

```
src/
??? FoundryTravel.Api/           # Web API layer (controllers, middleware)
??? FoundryTravel.Application/   # Application services and DTOs
??? FoundryTravel.Domain/        # Domain entities and interfaces
??? FoundryTravel.Infrastructure/# Data access and external services
```

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Azure OpenAI resource (for AI features)

### Configuration

Update `appsettings.json` with your Azure OpenAI credentials:

```json
{
  "AzureAI": {
    "Endpoint": "https://YOUR-ENDPOINT.openai.azure.com/",
    "ApiKey": "YOUR-KEY",
    "Deployment": "gpt-4o-mini"
  }
}
```

### Run the Application

```bash
cd src/FoundryTravel.Api
dotnet run
```

The API will be available at `https://localhost:5001` with Swagger UI at the root URL.

## API Endpoints

### Hotels

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/hotels/search` | Search hotels with filters (cityId, maxPrice, starRating, page, pageSize) |
| GET | `/api/hotels/{id}` | Get hotel by ID |

### AI

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/ai/search` | Natural language hotel search |
| POST | `/api/ai/recommend` | Get AI hotel recommendations |
| POST | `/api/ai/faq/{hotelId}` | Ask questions about a hotel |

## Domain Entities

- **City** – Name, Country
- **Hotel** – Name, Description, StarRating, BasePricePerNight, Address
- **RoomType** – Room configurations
- **Review** – Hotel reviews
- **Amenity** – Hotel amenities

## License

This project is licensed under the MIT License.
