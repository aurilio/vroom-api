namespace Vroom.Domain.Entities;

public class Bike
{
    public Guid Id { get; set; }

    public string Identifier { get; set; } = default!;

    public long Year { get; set; }

    public string Model { get; set; } = default!;

    public string Plate { get; set; } = default!;
}