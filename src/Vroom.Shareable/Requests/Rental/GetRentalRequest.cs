using MediatR;
using Vroom.Shareable.Responses.Rental;

namespace Vroom.Shareable.Requests.Rental;

public class GetRentalRequest : IRequest<GetRentalResponse>
{
    public Guid RentalId { get; set; }
}