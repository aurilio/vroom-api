using MediatR;
using Microsoft.AspNetCore.Http;

namespace Vroom.Shareable.Requests.Rental;

public class UpdateRentalRequest : IRequest<IResult>
{
    public Guid RentalId { get; set; }

    public DateTime ReturnDate { get; set; } = default!;
}