using MediatR;
using System.Text.Json.Serialization;
using Vroom.Shareable.DTOs;
using Vroom.Shareable.Responses.Bike;

namespace Vroom.Shareable.Requests.Bike;

public class UpdateBikeRequest : IRequest<UpdateBikeResponse>
{
    public Guid BikeId { get; set; }

    [JsonPropertyName("placa")]
    public PlateDTO Plate { get; set; } = default!;
}