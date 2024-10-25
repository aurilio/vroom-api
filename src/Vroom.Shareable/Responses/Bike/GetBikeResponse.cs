using Vroom.Shareable.DTOs;

namespace Vroom.Shareable.Responses.Bike;

public class GetBikeResponse
{
    public BikeDTO BikeDTO { get; set; } = new BikeDTO();
}