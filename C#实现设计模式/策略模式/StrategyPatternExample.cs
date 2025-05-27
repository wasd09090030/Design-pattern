using System;

namespace StrategyPatternExample
{
    // 🔹 1. 定义策略接口
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    // 🔹 2. 具体策略类 - 支付宝支付
    public class AlipayStrategy : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"使用支付宝支付了 {amount:C}");
        }
    }

    // 🔹 3. 具体策略类 - 微信支付
    public class WeChatPayStrategy : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"使用微信支付了 {amount:C}");
        }
    }

    // 🔹 4. 具体策略类 - 银行卡支付
    public class BankCardStrategy : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"使用银行卡支付了 {amount:C}");
        }
    }

    // 🔹 5. 上下文类，用于持有并使用具体的策略
    public class PaymentContext
    {
        private IPaymentStrategy _strategy;

        // 设置当前使用的支付策略
        public void SetStrategy(IPaymentStrategy strategy)
        {
            this._strategy = strategy;
        }

        // 执行支付操作
        public void ExecutePayment(double amount)
        {
            if (_strategy == null)
                throw new InvalidOperationException("未设置支付策略");

            _strategy.Pay(amount);
        }
    }

    // 🔹 6. 主程序入口
    class StrategyPatternExample
    {
        static void Main(string[] args)
        {
            // 创建支付上下文
            var paymentContext = new PaymentContext();

            // 模拟用户选择不同的支付方式
            Console.WriteLine("用户选择支付宝支付：");
            paymentContext.SetStrategy(new AlipayStrategy());
            paymentContext.ExecutePayment(199.99);

            Console.WriteLine("\n用户选择微信支付：");
            paymentContext.SetStrategy(new WeChatPayStrategy());
            paymentContext.ExecutePayment(88.50);

            Console.WriteLine("\n用户选择银行卡支付：");
            paymentContext.SetStrategy(new BankCardStrategy());
            paymentContext.ExecutePayment(500.00);
        }
    }
}