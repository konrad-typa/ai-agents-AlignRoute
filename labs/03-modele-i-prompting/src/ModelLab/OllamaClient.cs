using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

public sealed class OllamaClient(HttpClient http) : IClient
{
    private static readonly JsonSerializerOptions Options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    // format: null (zwykły tekst), "json" albo obiekt JSON Schema
    public async Task<string> GenerateAsync(
        string model,
        string prompt,
        double temperature = 0,
        object? format = null)
    {
        var request = new
        {
            model,
            messages = new[]
            {
                new { role = "user", content = prompt }
            },
            stream = false,
            format,
            options = new
            {
                temperature
            }
        };

        using var response = await http.PostAsJsonAsync(
            "http://localhost:11434/api/chat",
            request,
            Options);

        response.EnsureSuccessStatusCode();

        using var json = await response.Content
            .ReadFromJsonAsync<JsonDocument>();

        return json!.RootElement
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? "";
    }
}
