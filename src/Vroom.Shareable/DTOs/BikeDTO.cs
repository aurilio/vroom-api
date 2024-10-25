using System.Text.Json.Serialization;

namespace Vroom.Shareable.DTOs;

public class BikeDTO
{
    [JsonPropertyName("identificador")]
    public string Identifier { get; set; } = default!;

    [JsonPropertyName("ano")]
    public long Year { get; set; }

    [JsonPropertyName("modelo")]
    public string Model { get; set; } = default!;

    [JsonPropertyName("placa")]
    public string Plate { get; set; } = default!;
}