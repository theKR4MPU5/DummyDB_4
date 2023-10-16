using Newtonsoft.Json;

namespace DummyDB_4;

public class Column
{
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }

    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }
}