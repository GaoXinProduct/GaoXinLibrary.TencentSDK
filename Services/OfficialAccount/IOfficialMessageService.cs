using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>公众号基础消息服务接口（群发 / 模板管理）</summary>
public interface IOfficialMessageService
{
    /// <summary>根据标签进行群发</summary>
    Task<MassSendResponse> MassSendAllAsync(MassSendAllRequest request, CancellationToken ct = default);
    /// <summary>根据 OpenId 列表群发</summary>
    Task<MassSendResponse> MassSendAsync(MassSendRequest request, CancellationToken ct = default);
    /// <summary>删除群发</summary>
    Task<MassDeleteResponse> MassDeleteAsync(MassDeleteRequest request, CancellationToken ct = default);
    /// <summary>预览群发消息</summary>
    Task<MassPreviewResponse> MassPreviewAsync(MassPreviewRequest request, CancellationToken ct = default);
    /// <summary>查询群发消息发送状态</summary>
    Task<MassGetResponse> MassGetAsync(long msgId, CancellationToken ct = default);
    /// <summary>设置所属行业</summary>
    Task<SetIndustryResponse> SetIndustryAsync(SetIndustryRequest request, CancellationToken ct = default);
    /// <summary>获取设置的行业信息</summary>
    Task<GetIndustryResponse> GetIndustryAsync(CancellationToken ct = default);
    /// <summary>获得模板 ID</summary>
    Task<AddTemplateResponse> AddTemplateAsync(AddTemplateRequest request, CancellationToken ct = default);
    /// <summary>获取模板列表</summary>
    Task<GetTemplateListResponse> GetTemplateListAsync(CancellationToken ct = default);
    /// <summary>删除模板</summary>
    Task<DeleteTemplateResponse> DeleteTemplateAsync(string templateId, CancellationToken ct = default);
}

