public record Reservation
{
    public Room Room { get; init; }
    public DateTime DateTime { get; init; }
    public string ReserverName { get; init; }
}