using System;

namespace ProxyPatternExample
{
    // 主题接口 (Subject Interface)
    // 定义了 RealSubject 和 Proxy 的共同接口，这样 Proxy 就可以在任何使用 RealSubject 的地方被替换。
    public interface ISubject
    {
        void Request(); // 请求方法
    }

    // 真实主题类 (RealSubject Class)
    // 定义了 Proxy 所代表的真实对象。
    public class RealSubject : ISubject
    {
        public RealSubject()
        {
            // 模拟昂贵的资源初始化
            Console.WriteLine("真实主题 (RealSubject): 实例已创建。(可能是一个耗时的操作)");
        }

        public void Request()
        {
            Console.WriteLine("真实主题 (RealSubject): 正在处理请求。");
        }
    }

    // 代理类 (Proxy Class)
    // 保存一个引用使得代理可以访问实体。若 RealSubject 和 Subject 的接口相同，Proxy 会引用 Subject。
    // 控制对真实主题的访问，并且可能负责创建和删除它。
    // 其他功能依赖于代理的类型：
    // - 远程代理 (Remote Proxy) 负责对远程对象的请求进行编码和解码。
    // - 虚拟代理 (Virtual Proxy) 可以缓存关于真实主题的额外信息，以便延迟对它的访问。
    // - 保护代理 (Protection Proxy) 检查调用者是否具有执行请求所需的访问权限。
    public class Proxy : ISubject
    {
        private RealSubject _realSubject; // 对真实主题的引用
        private bool _canAccess;          // 示例：用于访问控制的标志

        public Proxy(bool canAccess)
        {
            _canAccess = canAccess;
            Console.WriteLine("代理 (Proxy): 实例已创建。");
        }

        // Proxy 实现与 RealSubject 相同的接口
        // 这使得客户端可以将 Proxy 视为 RealSubject
        public void Request()
        {
            if (CheckAccess()) // 代理可以在将请求传递给真实主题之前或之后执行其他操作
            {
                // 延迟初始化：仅在需要时创建 RealSubject
                if (_realSubject == null)
                {
                    Console.WriteLine("代理 (Proxy): 正在创建真实主题 (RealSubject) 实例...");
                    _realSubject = new RealSubject();
                }
                _realSubject.Request(); // 将请求委托给真实主题
                LogAccess();            // 代理可以在请求之后执行其他操作
            }
            else
            {
                Console.WriteLine("代理 (Proxy): 访问被拒绝。无法转发请求。");
            }
        }

        // 代理可以添加的额外功能，例如访问控制
        private bool CheckAccess()
        {
            Console.WriteLine("代理 (Proxy): 正在检查访问权限...");
            if (_canAccess)
            {
                Console.WriteLine("代理 (Proxy): 访问已授权。");
                return true;
            }
            // Console.WriteLine("代理 (Proxy): 访问被拒绝。"); // 这条信息在 Request 方法中更合适
            return false;
        }

        // 代理可以添加的额外功能，例如日志记录
        private void LogAccess()
        {
            Console.WriteLine($"代理 (Proxy): 记录请求时间 {DateTime.Now}。");
        }
    }

    // 客户端代码 (Client Code)
    // 客户端通过主题接口与对象交互，因此它不知道它是在与真实主题还是代理打交道。
    public class ProxyPattern
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("客户端: 使用代理执行客户端代码 (访问已授权):");
            // 客户端与代理交互，代理控制对真实对象的访问
            ISubject proxyWithAccess = new Proxy(canAccess: true);
            proxyWithAccess.Request(); // 第一次请求，会创建 RealSubject

            Console.WriteLine(); // 添加空行以提高可读性

            Console.WriteLine("客户端: 使用代理执行客户端代码 (访问被拒绝):");
            ISubject proxyWithoutAccess = new Proxy(canAccess: false);
            proxyWithoutAccess.Request(); // RealSubject 不会被创建，因为访问被拒绝

            Console.WriteLine(); // 添加空行以提高可读性

            Console.WriteLine("客户端: 再次使用授权的代理执行客户端代码 (第二次请求，验证 RealSubject 不会重新创建):");
            proxyWithAccess.Request(); // 第二次请求，RealSubject 已存在，不会重新创建
        }
    }
}
