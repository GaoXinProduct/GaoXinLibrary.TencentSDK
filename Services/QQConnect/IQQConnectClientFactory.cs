namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// QQ 互联客户端工厂接口
/// <para>
/// 当通过 <c>AddQQConnectService(name, ...)</c> 注册了多个具名 QQ 互联实例时，
/// 可通过此工厂在 <b>MVC Controller 构造函数</b>或普通服务中按名称获取对应的 <see cref="QQConnectClient"/> 实例。
/// </para>
/// <para>
/// 适用场景：MVC Controller 构造函数不支持 <c>[FromKeyedServices]</c>，注入工厂后通过 <see cref="CreateClient"/> 解析指定实例。
/// 通过 <see cref="QQConnectClient"/> 门面可访问 <c>.Login</c> 服务。
/// </para>
/// <example>
/// <b>注册（Program.cs）：</b>
/// <code>
/// builder.Services.AddQQConnectService("qq1", opt => { opt.AppId = "appid_1"; opt.AppSecret = "key_1"; });
/// builder.Services.AddQQConnectService("qq2", opt => { opt.AppId = "appid_2"; opt.AppSecret = "key_2"; });
/// </code>
///
/// <b>注入（MVC Controller）：</b>
/// <code>
/// public class MyController(IQQConnectClientFactory qqFactory) : ControllerBase
/// {
///     private readonly QQConnectClient _qq1 = qqFactory.CreateClient("qq1");
///     private readonly QQConnectClient _qq2 = qqFactory.CreateClient("qq2");
/// }
/// </code>
/// </example>
/// </summary>
public interface IQQConnectClientFactory
{
    /// <summary>
    /// 按名称获取指定 QQ 互联客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddQQConnectService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="QQConnectClient"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的 QQ 互联服务未注册时抛出</exception>
    QQConnectClient CreateClient(string name);
}
