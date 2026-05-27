namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class GetLayoutTemplateListRequest
{
    public string SuiteId { get; set; } = string.Empty;
    public int TemplateType { get; set; }
}