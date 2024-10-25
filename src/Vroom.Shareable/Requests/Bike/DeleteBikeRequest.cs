using MediatR;
using Vroom.Shareable.Responses.Bike;

namespace Vroom.Shareable.Requests.Bike;

public class DeleteBikeRequest : IRequest<DeleteBikeResponse>
{
    public Guid BikeId { get; set; }
}