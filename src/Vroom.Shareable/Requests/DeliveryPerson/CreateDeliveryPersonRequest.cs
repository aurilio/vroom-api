using MediatR;
using Microsoft.AspNetCore.Http;
using Vroom.Shareable.DTOs;

namespace Vroom.Shareable.Requests.DeliveryPerson;

public class CreateDeliveryPersonRequest : IRequest<IResult>
{
    public DeliveryPersonDTO DeliveryPersonDTO { get; set; } = default!;
}