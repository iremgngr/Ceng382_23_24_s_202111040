public record LogRecord
{
    public string Message { get; init; }
    public DateTime Timestamp { get; init; }
}