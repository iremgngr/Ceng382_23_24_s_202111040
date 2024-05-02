public record LogRecord
{
    public string Message { get; init; }
    public DateTime Timestamp { get; init; }
}

namespace MyNamespace
{
    public static class ReservationLogger
    {
        public static void LogReservationAction(string message)
        {
            var logRecord = new LogRecord
            {
                Message = message,
                Timestamp = DateTime.Now
            };

            string logJson = System.Text.Json.JsonSerializer.Serialize(logRecord);
            File.AppendAllText("LogData.json", logJson + Environment.NewLine);
        }
    }
}





