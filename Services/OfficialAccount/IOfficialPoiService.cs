using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>公众号微信门店服务接口</summary>
public interface IOfficialPoiService
{
    /// <summary>创建门店</summary>
    Task<AddPoiResponse> AddAsync(AddPoiRequest request, CancellationToken ct = default);
    /// <summary>查询门店信息</summary>
    Task<GetPoiResponse> GetAsync(string poiId, CancellationToken ct = default);
    /// <summary>查询门店列表</summary>
    Task<GetPoiListResponse> GetListAsync(GetPoiListRequest request, CancellationToken ct = default);
    /// <summary>修改门店服务信息</summary>
    Task<UpdatePoiResponse> UpdateAsync(UpdatePoiRequest request, CancellationToken ct = default);
    /// <summary>删除门店</summary>
    Task<DeletePoiResponse> DeleteAsync(string poiId, CancellationToken ct = default);
}

