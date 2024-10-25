namespace Vroom.Shareable.Responses.Rental;

public class GetRentalResponse
{
    public Guid RentalId { get; set; }

    public decimal ValorDiaria { get; set; }

    public Guid DeliveryPersonId { get; set; }

    public Guid BikeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime ExpectedEndDate { get; set; }

    public DateTime ReturnDate { get; set; }
}