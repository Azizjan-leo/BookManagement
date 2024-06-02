using System.Text.Json.Serialization;

namespace BookManagement.Model;

public sealed record OperationResult
{
    public bool IsSucceed { get; set; }

    public object? Value { get; set; }

    public string? Message { get; set; }

    [JsonIgnore]
    public string? LogText { get; set; }
}
