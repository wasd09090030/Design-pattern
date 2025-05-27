namespace 装饰模式
{
    // Component（组件）接口：定义了一个对象接口，可以给这些对象动态地添加职责。
    public interface IComponent
    {
        string Operation();
    }

    // ConcreteComponent（具体组件）：定义了一个具体的对象，可以给这个对象添加一些职责。
    internal class ConcreteComponent : IComponent
    {
        public string Operation()
        {
            return "ConcreteComponent";
        }
    }

    // Decorator（装饰器）抽象类：继承自 Component，从外类来扩展 Component 类的功能，但对于 Component 来说，是无需知道 Decorator 的存在的。
    // 它持有一个 Component 对象的实例，并定义一个与 Component 接口一致的接口。
    internal abstract class Decorator : IComponent
    {
        protected IComponent _component;

        public Decorator(IComponent component)
        {
            this._component = component;
        }

        // 装饰器将所有工作委派给包装的组件。
        public virtual string Operation()
        {
            if (_component != null)
            {
                return _component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    // ConcreteDecoratorA（具体装饰器 A）：向组件添加职责。
    internal class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent comp) : base(comp)
        {
        }

        // 具体装饰器可以在调用父类实现之前或之后执行它们自己的行为。
        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    // ConcreteDecoratorB（具体装饰器 B）：向组件添加职责。
    internal class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }

        // 装饰器可以添加新的方法，而不仅仅是重写现有方法。
        public string AddedBehavior()
        {
            return "AddedBehavior by ConcreteDecoratorB";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 创建一个具体组件对象
            ConcreteComponent simple = new ConcreteComponent();
            Console.WriteLine("客户端：我有一个简单的组件:");
            ClientCode(simple);
            Console.WriteLine();

            // 现在，用 ConcreteDecoratorA 来装饰它
            ConcreteDecoratorA decoratorA = new ConcreteDecoratorA(simple);
            Console.WriteLine("客户端：现在我有一个被装饰过的组件:");
            ClientCode(decoratorA);
            Console.WriteLine();

            // 还可以用 ConcreteDecoratorB 来装饰 ConcreteDecoratorA
            // 装饰器可以包装其他装饰器，也可以包装具体组件。
            ConcreteDecoratorB decoratorB = new ConcreteDecoratorB(decoratorA);
            Console.WriteLine("客户端：现在我有一个被双重装饰过的组件:");
            ClientCode(decoratorB);
            Console.WriteLine();

            // ConcreteDecoratorB 还可以调用其特有的方法
            Console.WriteLine("客户端：调用 ConcreteDecoratorB 的特有方法:");
            Console.WriteLine($"结果: {decoratorB.AddedBehavior()}");
        }

        // 客户端代码使用 Component 接口与所有对象进行交互。
        // 这样，它就可以与具体组件和装饰器保持独立。
        public static void ClientCode(IComponent component)
        {
            Console.WriteLine($"结果: {component.Operation()}");
        }
    }
}
