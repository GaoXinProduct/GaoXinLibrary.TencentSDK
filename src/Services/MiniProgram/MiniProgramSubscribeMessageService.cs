using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序订阅消息服务实现</summary>
public sealed class MiniProgramSubscribeMessageService
{
    private readonly WechatHttpClient _http;

    public MiniProgramSubscribeMessageService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <summary>
    /// 发送订阅消息（subscribeMessage.send）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<SendSubscribeMessageResponse> SendAsync(SendSubscribeMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SendSubscribeMessageResponse>("/cgi-bin/message/subscribe/send", request, ct);

    /// <summary>
    /// 获取类目（GET /wxa/get_category）
    /// <para>获取小程序模板消息的类目列表。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    public Task<GetCategoryResponse> GetCategoryAsync(CancellationToken ct = default)
        => _http.GetAsync<GetCategoryResponse>("/wxa/get_category", null, ct);

    /// <summary>
    /// 获取类目下的公共模板列表（GET /wxa/get_pub_template_titles）
    /// <para>根据类目获取模板标题列表。</para>
    /// </summary>
    /// <param name="request">查询参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetPubTemplateTitlesResponse> GetPubTemplateTitlesAsync(GetPubTemplateTitlesRequest request, CancellationToken ct = default)
        => _http.GetAsync<GetPubTemplateTitlesResponse>("/wxa/get_pub_template_titles", 
            new Dictionary<string, string?> { ["ids"] = request.Ids, ["start"] = request.Start.ToString(), ["limit"] = request.Limit.ToString() }, ct);

    /// <summary>
    /// 获取模板中的关键词列表（GET /wxa/get_pub_template_keywords）
    /// <para>获取指定模板标题中的关键词列表。</para>
    /// </summary>
    /// <param name="request">查询参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetPubTemplateKeywordsResponse> GetPubTemplateKeywordsAsync(GetPubTemplateKeywordsRequest request, CancellationToken ct = default)
        => _http.GetAsync<GetPubTemplateKeywordsResponse>("/wxa/get_pub_template_keywords",
            new Dictionary<string, string?> { ["tid"] = request.TemplateId.ToString() }, ct);

    /// <summary>
    /// 获取已添加的模板列表（GET /wxa/get_template_list）
    /// <para>获取用户已添加的模板消息列表。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    public Task<GetTemplateListResponse> GetTemplateListAsync(CancellationToken ct = default)
        => _http.GetAsync<GetTemplateListResponse>("/wxa/get_template_list", null, ct);

    /// <summary>
    /// 选用模板（POST /wxa/add_template）
    /// <para>将已获取的模板标题添加到用户自己的模板库中。</para>
    /// </summary>
    /// <param name="request">选用请求</param>
    /// <param name="ct">取消令牌</param>
    public Task<AddTemplateResponse> AddTemplateAsync(AddTemplateRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddTemplateResponse>("/wxa/add_template", request, ct);

    /// <summary>
    /// 删除模板消息（POST /wxa/del_template）
    /// <para>删除已添加的模板消息。</para>
    /// </summary>
    /// <param name="request">删除请求</param>
    /// <param name="ct">取消令牌</param>
    public Task<DelTemplateResponse> DelTemplateAsync(DelTemplateRequest request, CancellationToken ct = default)
        => _http.PostAsync<DelTemplateResponse>("/wxa/del_template", request, ct);
}
