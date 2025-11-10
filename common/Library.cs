using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebAecCommon;

public class Location
{
    public double lat { get; set; }
    public double lon { get; set; }
}

public class CommonElement
{
    public string id { get; set; }
    public string name { get; set; }
    public Dictionary<string, string> properties { get; set; }

    public CommonElement(string id, string name, Dictionary<string, string> properties)
    {
        this.id = id;
        this.name = name;
        this.properties = properties;
    }
}

public class BridgeMessage
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("data")]
    public object Data { get; set; }
}
