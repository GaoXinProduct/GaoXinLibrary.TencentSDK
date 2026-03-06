using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号基础消息服务实现</summary>
public class OfficialMessageService : IOfficialMessageService
{
    private readonly WechatHttpClient _http;
    public OfficialMessageService(WechatHttpClient http) => _http = http;

    public Task<MassSendResponse> MassSendAllAsync(MassSendAllRequest request, CancellationToken ct = default)
        => _http.PostAsync<MassSendResponse>("/cgi-bin/message/mass/sendall", request, ct);

    public Task<MassSendResponse> MassSendAsync(MassSendRequest request, CancellationToken ct = default)
        => _http.PostAsync<MassSendResponse>("/cgi-bin/message/mass/send", request, ct);

    public Task<MassDeleteResponse> MassDeleteAsync(MassDeleteRequest request, CancellationToken ct = default)
        => _http.PostAsync<MassDeleteResponse>("/cgi-bin/message/mass/delete", request, ct);

    public Task<MassPreviewResponse> MassPreviewAsync(MassPreviewRequest request, CancellationToken ct = default)
        => _http.PostAsync<MassPreviewResponse>("/cgi-bin/message/mass/preview", request, ct);

    public Task<MassGetResponse> MassGetAsync(long msgId, CancellationToken ct = default)
        => _http.PostAsync<MassGetResponse>("/cgi-bin/message/mass/get", new MassGetRequest { MsgId = msgId }, ct);

    public Task<SetIndustryResponse> SetIndustryAsync(SetIndustryRequest request, CancellationToken ct = default)
        => _http.PostAsync<SetIndustryResponse>("/cgi-bin/template/api_set_industry", request, ct);

    public Task<GetIndustryResponse> GetIndustryAsync(CancellationToken ct = default)
        => _http.GetAsync<GetIndustryResponse>("/cgi-bin/template/get_industry", ct: ct);

    public Task<AddTemplateResponse> AddTemplateAsync(AddTemplateRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddTemplateResponse>("/cgi-bin/template/api_add_template", request, ct);

    public Task<GetTemplateListResponse> GetTemplateListAsync(CancellationToken ct = default)
        => _http.GetAsync<GetTemplateListResponse>("/cgi-bin/template/get_all_private_template", ct: ct);

    public Task<DeleteTemplateResponse> DeleteTemplateAsync(string templateId, CancellationToken ct = default)
        => _http.PostAsync<DeleteTemplateResponse>("/cgi-bin/template/del_private_template", new DeleteTemplateRequest { TemplateId = templateId }, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号数据统计服务

