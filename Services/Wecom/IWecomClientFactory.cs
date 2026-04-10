namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 企业微信客户端工厂接口
/// <para>
/// 当通过 <c>AddWecomService(name, ...)</c> 注册了多个具名企业微信实例时，
/// 可通过此工厂在 <b>MVC Controller 构造函数</b>或普通服务中按名称获取对应的 <see cref="WecomClient"/> 实例。
/// </para>
/// <para>
/// 适用场景：MVC Controller 构造函数不支持 <c>[FromKeyedServices]</c>，注入工厂后通过 <see cref="CreateClient"/> 解析指定实例。
/// 通过 <see cref="WecomClient"/> 门面可访问全部子服务（<c>.Message</c>、<c>.User</c>、<c>.Department</c> 等）。
/// </para>
/// <example>
/// <b>注册（Program.cs）：</b>
/// <code>
/// builder.Services.AddWecomService("agent1", opt => { opt.CorpId = "corp1"; opt.CorpSecret = "secret1"; opt.AgentId = 1000001; });
/// builder.Services.AddWecomService("agent2", opt => { opt.CorpId = "corp1"; opt.CorpSecret = "secret2"; opt.AgentId = 1000002; });
/// </code>
///
/// <b>注入（MVC Controller）：</b>
/// <code>
/// public class MyController(IWecomClientFactory wecomFactory) : ControllerBase
/// {
///     private readonly WecomClient _agent1 = wecomFactory.CreateClient("agent1");
///     private readonly WecomClient _agent2 = wecomFactory.CreateClient("agent2");
/// }
/// </code>
/// </example>
/// </summary>
public interface IWecomClientFactory
{
    /// <summary>
    /// 按名称获取指定企业微信客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWecomService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="WecomClient"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的企业微信服务未注册时抛出</exception>
    WecomClient CreateClient(string name);
}
