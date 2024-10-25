using MediatR;
using Microsoft.AspNetCore.Http;
using Vroom.Shareable.DTOs;

namespace Vroom.Shareable.Requests.Bike;

public class CreateBikeRequest : IRequest<IResult>
{
    public BikeDTO BikeDTO { get; set; } = default!;
}