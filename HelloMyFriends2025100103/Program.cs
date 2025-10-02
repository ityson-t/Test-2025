using System.Xml;

namespace HelloMyFriends2025100103
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //要求用户输入名字
            Console.Write($"请输入你的名字：");
            //声明变量name用于接收用户输入
            string name = Console.ReadLine();
            //当用户输入不为exit时进行下一步判断
            while (name != "exit")
            {
                //当输入为空时，要求用户重新输入并接收
                if (name == "")
                {
                    Console.Write($"您没有输入名字，请重新输入：");
                    name = Console.ReadLine();
                    //使用continue继续判断name是否为空
                    continue;
                }
                //用户输入不为空时，转换首字母大写，输出结果，并要求再次输入名字

                //声明一个变量，将用户输入字符首字母大家后存入此变量
                string properName = char.ToUpper(name[0]) + name.Substring(1);
                //打印结果
                Console.WriteLine($"你好，{properName}！");
                //要求用户再次输入
                Console.Write($"请输入你的名字：");
                //接收用户输入
                name = Console.ReadLine();

            }
            //用户输入exit时，结果程序
            Console.WriteLine($"再见！");
        }
    }
}
