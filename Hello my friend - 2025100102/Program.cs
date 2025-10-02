namespace Hello_my_friend___2025100102
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //提示用户输入名字
            Console.WriteLine("请输入你的名字：");
            //声名一个字符串类型变量，接收用户输入
            string name = Console.ReadLine();
            //打印结果
            Console.WriteLine($"你好{name}。");
        }
    }
}
