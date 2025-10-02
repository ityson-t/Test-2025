namespace Week1_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "张一元";
            int age = 103;
            double height = 1.78;
            bool likeCode = true;
            Console.WriteLine($"""===我的个人信息===\n姓名：{name}\n年龄：{age}\n身高：{height}米\n喜欢编程吗？{(likeCode ? "是" : "否")}""");
        }
    }
}
