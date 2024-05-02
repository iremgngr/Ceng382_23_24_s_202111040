using System.Text.Json.Serialization;

public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[] Rooms { get; set; }
}
public record Room
{
        public string roomId { get; init; }
        public string roomName { get; init; }
        public int capacity { get; init; }
}

