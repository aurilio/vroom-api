using MediatR;
using Vroom.Shareable.Responses.Bike;

namespace Vroom.Shareable.Requests.Bike;

public class GetAllBikesRequest : IRequest<GetAllBikeResponse>
{
}