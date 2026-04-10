namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 微信小程序客户端工厂接口
/// <para>
/// 当通过 <c>AddWechatMiniProgramService(name, ...)</c> 注册了多个具名小程序实例时，
/// 可通过此工厂在 <b>MVC Controller 构造函数</b>或普通服务中按名称获取对应的 <see cref="WechatMiniProgramClient"/> 实例。
/// </para>
/// <para>
/// 适用场景：MVC Controller 构造函数不支持 <c>[FromKeyedServices]</c>，注入工厂后通过 <see cref="CreateClient"/> 解析指定实例。
/// 通过 <see cref="WechatMiniProgramClient"/> 门面可访问全部子服务（<c>.Auth</c>、<c>.QrCode</c>、<c>.SubscribeMessage</c> 等）。
/// </para>
/// <example>
/// <b>注册（Program.cs）：</b>
/// <code>
/// builder.Services.AddWechatMiniProgramService("appA", opt => { opt.AppId = "appid_a"; opt.AppSecret = "secret_a"; });
/// builder.Services.AddWechatMiniProgramService("appB", opt => { opt.AppId = "appid_b"; opt.AppSecret = "secret_b"; });
/// </code>
///
/// <b>注入（MVC Controller）：</b>
/// <code>
/// public class MyController(IWechatMiniProgramClientFactory miniFactory) : ControllerBase
/// {
///     private readonly WechatMiniProgramClient _appA = miniFactory.CreateClient("appA");
///     private readonly WechatMiniProgramClient _appB = miniFactory.CreateClient("appB");
/// }
/// </code>
/// </example>
/// </summary>
public interface IWechatMiniProgramClientFactory
{
    /// <summary>
    /// 按名称获取指定微信小程序客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWechatMiniProgramService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="WechatMiniProgramClient"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的小程序服务未注册时抛出</exception>
    WechatMiniProgramClient CreateClient(string name);
}
