using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 腾讯平台 API 基础响应
/// </summary>
public abstract class TencentBaseResponse
{
    /// <summary>错误码，0 表示成功</summary>
    [JsonPropertyName("errcode")]
    [JsonConverter(typeof(StringOrIntJsonConverter))]
    public int ErrCode { get; set; }

    /// <summary>错误信息</summary>
    [JsonPropertyName("errmsg")]
    public string? ErrMsg { get; set; }
}

/// <summary>将 JSON 字符串或整数读取为 <see cref="int"/>（应对少数微信接口返回字符串形式 errcode 的情况）</summary>
internal sealed class StringOrIntJsonConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var s = reader.GetString();
            return int.TryParse(s, out var i) ? i : 0;
        }
        return reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        => writer.WriteNumberValue(value);
}
