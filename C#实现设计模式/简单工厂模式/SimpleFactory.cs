namespace 简单工厂模式
{
    // 产品接口
    public interface IProduct
    {
        void Operate();
    }

    // 具体产品A
    public class ConcreteProductA : IProduct
    {
        public void Operate()
        {
            Console.WriteLine("ConcreteProductA operation.");
        }
    }

    // 具体产品B
    public class ConcreteProductB : IProduct
    {
        public void Operate()
        {
            Console.WriteLine("ConcreteProductB operation.");
        }
    }

    // 简单工厂
    public class SimpleFactory
    {
        public static IProduct CreateProduct(string type)
        {
            switch (type)
            {
                case "A":
                    return new ConcreteProductA();
                case "B":
                    return new ConcreteProductB();
                default:
                    throw new ArgumentException("Invalid product type.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 使用工厂创建产品A
            IProduct productA = SimpleFactory.CreateProduct("A");
            productA.Operate(); // 输出: ConcreteProductA operation.

            // 使用工厂创建产品B
            IProduct productB = SimpleFactory.CreateProduct("B");
            productB.Operate(); // 输出: ConcreteProductB operation.
        }
    }
}
