using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号微信门店服务实现</summary>
public class OfficialPoiService
{
    private readonly WechatHttpClient _http;
    public OfficialPoiService(WechatHttpClient http) => _http = http;

    /// <summary>创建门店</summary>
    public Task<AddPoiResponse> AddAsync(AddPoiRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddPoiResponse>("/cgi-bin/poi/addpoi", request, ct);

    /// <summary>查询门店信息</summary>
    public Task<GetPoiResponse> GetAsync(string poiId, CancellationToken ct = default)
        => _http.PostAsync<GetPoiResponse>("/cgi-bin/poi/getpoi", new GetPoiRequest { PoiId = poiId }, ct);

    /// <summary>查询门店列表</summary>
    public Task<GetPoiListResponse> GetListAsync(GetPoiListRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetPoiListResponse>("/cgi-bin/poi/getpoilist", request, ct);

    /// <summary>修改门店服务信息</summary>
    public Task<UpdatePoiResponse> UpdateAsync(UpdatePoiRequest request, CancellationToken ct = default)
        => _http.PostAsync<UpdatePoiResponse>("/cgi-bin/poi/updatepoi", request, ct);

    /// <summary>删除门店</summary>
    public Task<DeletePoiResponse> DeleteAsync(string poiId, CancellationToken ct = default)
        => _http.PostAsync<DeletePoiResponse>("/cgi-bin/poi/delpoi", new DeletePoiRequest { PoiId = poiId }, ct);
}
