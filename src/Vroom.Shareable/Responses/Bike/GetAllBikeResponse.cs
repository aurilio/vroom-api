using Vroom.Shareable.DTOs;

namespace Vroom.Shareable.Responses.Bike;

public class GetAllBikeResponse
{
    public List<BikeDTO> Tasks { get; set; } = new List<BikeDTO>();
}