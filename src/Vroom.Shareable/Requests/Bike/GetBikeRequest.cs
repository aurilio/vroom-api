using MediatR;
using Vroom.Shareable.Responses.Bike;

namespace Vroom.Shareable.Requests.Bike;

public class GetBikeRequest : IRequest<GetBikeResponse>
{
    public Guid BikeId { get; set; }
}