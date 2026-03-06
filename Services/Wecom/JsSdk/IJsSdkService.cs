using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.JsSdk;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 企业微信 H5 / JS-SDK 服务接口
/// <para>
/// 提供企业微信 JS-SDK 所需的 jsapi_ticket 获取、签名计算等功能，
/// 用于在企业微信 H5 页面中调用 JS-SDK 接口。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90506"/>
/// </para>
/// </summary>
public interface IJsSdkService
{
    /// <summary>
    /// 获取企业的 jsapi_ticket
    /// <para>一小时内，一个企业最多可获取400次，且单个应用不能超过100次。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>jsapi_ticket 及有效时间</returns>
    Task<GetJsApiTicketResponse> GetJsApiTicketAsync(CancellationToken ct = default);

    /// <summary>
    /// 获取应用的 jsapi_ticket（用于 agentConfig 注入）
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>应用级别的 jsapi_ticket 及有效时间</returns>
    Task<GetAgentTicketResponse> GetAgentTicketAsync(CancellationToken ct = default);

    /// <summary>
    /// 计算企业级别的 JS-SDK 签名（用于 wx.config）
    /// </summary>
    /// <param name="ticket">通过 <see cref="GetJsApiTicketAsync"/> 获取的 jsapi_ticket</param>
    /// <param name="url">当前网页的完整 URL（不包含 # 及其后面部分）</param>
    /// <returns>签名结果</returns>
    JsSdkSignature CreateSignature(string ticket, string url);

    /// <summary>
    /// 计算应用级别的 JS-SDK 签名（用于 wx.agentConfig）
    /// </summary>
    /// <param name="ticket">通过 <see cref="GetAgentTicketAsync"/> 获取的应用 jsapi_ticket</param>
    /// <param name="url">当前网页的完整 URL（不包含 # 及其后面部分）</param>
    /// <returns>应用级别签名结果</returns>
    AgentJsSdkSignature CreateAgentSignature(string ticket, string url);
}
