namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 微信开放平台客户端工厂接口
/// <para>
/// 当通过 <c>AddWechatOpenService(name, ...)</c> 注册了多个具名开放平台实例时，
/// 可通过此工厂在 <b>MVC Controller 构造函数</b>或普通服务中按名称获取对应的 <see cref="WechatOpenClient"/> 实例。
/// </para>
/// <para>
/// 适用场景：MVC Controller 构造函数不支持 <c>[FromKeyedServices]</c>，注入工厂后通过 <see cref="CreateClient"/> 解析指定实例。
/// 通过 <see cref="WechatOpenClient"/> 门面可访问 <c>.WebLogin</c> 服务。
/// </para>
/// <example>
/// <b>注册（Program.cs）：</b>
/// <code>
/// builder.Services.AddWechatOpenService("open1", opt => { opt.AppId = "appid_1"; opt.AppSecret = "secret_1"; });
/// builder.Services.AddWechatOpenService("open2", opt => { opt.AppId = "appid_2"; opt.AppSecret = "secret_2"; });
/// </code>
///
/// <b>注入（MVC Controller）：</b>
/// <code>
/// public class MyController(IWechatOpenClientFactory openFactory) : ControllerBase
/// {
///     private readonly WechatOpenClient _open1 = openFactory.CreateClient("open1");
///     private readonly WechatOpenClient _open2 = openFactory.CreateClient("open2");
/// }
/// </code>
/// </example>
/// </summary>
public interface IWechatOpenClientFactory
{
    /// <summary>
    /// 按名称获取指定微信开放平台客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWechatOpenService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="WechatOpenClient"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的开放平台服务未注册时抛出</exception>
    WechatOpenClient CreateClient(string name);
}
