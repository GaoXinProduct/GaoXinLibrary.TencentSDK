using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号基础消息服务实现</summary>
public class OfficialMessageService
{
    private readonly WechatHttpClient _http;
    public OfficialMessageService(WechatHttpClient http) => _http = http;

    /// <summary>根据标签进行群发</summary>
    public Task<MassSendResponse> MassSendAllAsync(MassSendAllRequest request, CancellationToken ct = default)
        => _http.PostAsync<MassSendResponse>("/cgi-bin/message/mass/sendall", request, ct);

    /// <summary>根据 OpenId 列表群发</summary>
    public Task<MassSendResponse> MassSendAsync(MassSendRequest request, CancellationToken ct = default)
        => _http.PostAsync<MassSendResponse>("/cgi-bin/message/mass/send", request, ct);

    /// <summary>删除群发</summary>
    public Task<MassDeleteResponse> MassDeleteAsync(MassDeleteRequest request, CancellationToken ct = default)
        => _http.PostAsync<MassDeleteResponse>("/cgi-bin/message/mass/delete", request, ct);

    /// <summary>预览群发消息</summary>
    public Task<MassPreviewResponse> MassPreviewAsync(MassPreviewRequest request, CancellationToken ct = default)
        => _http.PostAsync<MassPreviewResponse>("/cgi-bin/message/mass/preview", request, ct);

    /// <summary>查询群发消息发送状态</summary>
    public Task<MassGetResponse> MassGetAsync(long msgId, CancellationToken ct = default)
        => _http.PostAsync<MassGetResponse>("/cgi-bin/message/mass/get", new MassGetRequest { MsgId = msgId }, ct);

    /// <summary>设置所属行业</summary>
    public Task<SetIndustryResponse> SetIndustryAsync(SetIndustryRequest request, CancellationToken ct = default)
        => _http.PostAsync<SetIndustryResponse>("/cgi-bin/template/api_set_industry", request, ct);

    /// <summary>获取设置的行业信息</summary>
    public Task<GetIndustryResponse> GetIndustryAsync(CancellationToken ct = default)
        => _http.GetAsync<GetIndustryResponse>("/cgi-bin/template/get_industry", ct: ct);

    /// <summary>获得模板 ID</summary>
    public Task<AddTemplateResponse> AddTemplateAsync(AddTemplateRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddTemplateResponse>("/cgi-bin/template/api_add_template", request, ct);

    /// <summary>获取模板列表</summary>
    public Task<GetTemplateListResponse> GetTemplateListAsync(CancellationToken ct = default)
        => _http.GetAsync<GetTemplateListResponse>("/cgi-bin/template/get_all_private_template", ct: ct);

    /// <summary>删除模板</summary>
    public Task<DeleteTemplateResponse> DeleteTemplateAsync(string templateId, CancellationToken ct = default)
        => _http.PostAsync<DeleteTemplateResponse>("/cgi-bin/template/del_private_template", new DeleteTemplateRequest { TemplateId = templateId }, ct);
}
