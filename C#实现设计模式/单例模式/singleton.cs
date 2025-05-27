using System;

public sealed class Singleton
{
    // 静态只读字段，保证只实例化一次
    private static readonly Singleton _instance = new Singleton();

    // 私有构造函数，防止外部实例化
    private Singleton()
    {
        Console.WriteLine("Singleton 实例已创建。");
    }

    // 公共静态属性，提供全局访问点
    public static Singleton Instance
    {
        get
        {
            return _instance;
        }
    }

    // 示例方法
    public void ShowMessage()
    {
        Console.WriteLine("Hello from Singleton!");
    }
}

class Mysingleton
{
    static void Main(string[] args)
    {
        // 获取单例实例
        Singleton s1 = Singleton.Instance;
        Singleton s2 = Singleton.Instance;

        s1.ShowMessage();

        // 验证两个引用是否指向同一个实例
        Console.WriteLine(object.ReferenceEquals(s1, s2)); // 输出 True
    }
}