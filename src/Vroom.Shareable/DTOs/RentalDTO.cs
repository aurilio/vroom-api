using System.Text.Json.Serialization;

namespace Vroom.Shareable.DTOs;

public class RentalDTO
{
    [JsonPropertyName("entregadorId")]
    public string DeliveryPersonId { get; set; } = default!;

    [JsonPropertyName("motoId")]
    public string BikeId { get; set; } = default!;

    [JsonPropertyName("dataInicio")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("dataTermino")]
    public DateTime EndDate { get; set; }

    [JsonPropertyName("dataPrevisaoTermino")]
    public DateTime ExpectedEndDate { get; set; }

    [JsonPropertyName("plano")]
    public int Plan { get; set; }
}