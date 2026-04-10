namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 微信公众号客户端工厂接口
/// <para>
/// 当通过 <c>AddWechatOfficialService(name, ...)</c> 注册了多个具名公众号实例时，
/// 可通过此工厂在 <b>MVC Controller 构造函数</b>或普通服务中按名称获取对应的 <see cref="WechatOfficialClient"/> 实例。
/// </para>
/// <para>
/// 适用场景：MVC Controller 构造函数不支持 <c>[FromKeyedServices]</c>，注入工厂后通过 <see cref="CreateClient"/> 解析指定实例。
/// 通过 <see cref="WechatOfficialClient"/> 门面可访问全部子服务（<c>.OAuth</c>、<c>.TemplateMessage</c>、<c>.User</c> 等）。
/// </para>
/// <example>
/// <b>注册（Program.cs）：</b>
/// <code>
/// builder.Services.AddWechatOfficialService("official1", opt => { opt.AppId = "appid_1"; opt.AppSecret = "secret_1"; });
/// builder.Services.AddWechatOfficialService("official2", opt => { opt.AppId = "appid_2"; opt.AppSecret = "secret_2"; });
/// </code>
///
/// <b>注入（MVC Controller）：</b>
/// <code>
/// public class MyController(IWechatOfficialClientFactory officialFactory) : ControllerBase
/// {
///     private readonly WechatOfficialClient _official1 = officialFactory.CreateClient("official1");
///     private readonly WechatOfficialClient _official2 = officialFactory.CreateClient("official2");
/// }
/// </code>
/// </example>
/// </summary>
public interface IWechatOfficialClientFactory
{
    /// <summary>
    /// 按名称获取指定微信公众号客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWechatOfficialService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="WechatOfficialClient"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的公众号服务未注册时抛出</exception>
    WechatOfficialClient CreateClient(string name);
}
