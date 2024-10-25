using System.Text.Json.Serialization;

namespace Vroom.Shareable.DTOs;

public class DeliveryPersonDTO
{
    [JsonPropertyName("identificador")]
    public string Identificador { get; set; } = default!;

    [JsonPropertyName("nome")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; } = default!;

    [JsonPropertyName("dataNascimento")]
    public DateTime BirthDate { get; set; }

    [JsonPropertyName("numeroCnh")]
    public string DriverNumber { get; set; } = default!;

    [JsonPropertyName("tipoCnh")]
    public string DriverType { get; set; } = default!;

    [JsonPropertyName("imagemCnh")]
    public string DriverImage { get; set; } = default!;
}