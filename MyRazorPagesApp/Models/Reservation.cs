public class Reservation
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? ReserverName { get; set; }
    public int RoomId { get; set; }

}