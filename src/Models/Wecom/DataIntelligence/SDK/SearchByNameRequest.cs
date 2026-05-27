using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SearchByNameRequest
{
    [JsonPropertyName("search_word")]
    public string? SearchWord { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 10;

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}