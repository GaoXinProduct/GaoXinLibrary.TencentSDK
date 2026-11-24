namespace GaoXinLibrary.TencentSDK.Wecom.Models.Media;

/// <summary>临时素材下载分块返回的字节范围</summary>
/// <param name="Start">分块的起始字节位置，从 0 开始</param>
/// <param name="End">分块的结束字节位置，包含该字节</param>
/// <param name="TotalLength">素材的总字节数</param>
public sealed record MediaDownloadRange(long Start, long End, long TotalLength);
