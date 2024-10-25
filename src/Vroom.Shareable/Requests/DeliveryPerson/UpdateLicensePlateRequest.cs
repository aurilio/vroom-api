using MediatR;
using Microsoft.AspNetCore.Http;

namespace Vroom.Shareable.Requests.DeliveryPerson;

public class UpdateLicensePlateRequest : IRequest<IResult>
{
    public Guid DeliveryPersonId { get; set; }

    public string LicensePlate { get; set; } = default!;
}