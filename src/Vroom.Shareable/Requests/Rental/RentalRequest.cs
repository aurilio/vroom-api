using MediatR;
using Microsoft.AspNetCore.Http;
using Vroom.Shareable.DTOs;

namespace Vroom.Shareable.Requests.Rental;

public class RentalRequest : IRequest<IResult>
{
    public RentalDTO RentalDTO { get; set; } = default!;
}