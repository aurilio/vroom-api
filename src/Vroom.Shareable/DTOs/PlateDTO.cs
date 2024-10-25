using System.Text.Json.Serialization;

namespace Vroom.Shareable.DTOs;

public class PlateDTO
{
    [JsonPropertyName("placa")]
    public string Plate { get; set; } = default!;
}