using System.Globalization;

namespace 累加器
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //输入一个正整数 n，计算 1+2+3+...+n 的结果。输入非法值（负数 / 字母），提示重新输入。
            //请求用户输入
            Console.Write("请输入一个正整数：");
            //声明字符串变量接收用户输入
            string userInput = Console.ReadLine();
            //判断输入：不是exit继续进行循环
            while (!userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                //声明int类型变量用于存储转换后的整数
                int num = 0;
                //判断输入数字是否能转换为整数
                if (int.TryParse(userInput, out num) && num > 0)
                {
                    //声明整型变量sum，存储累加值
                    int sum = 0;
                    //循环累加
                    for (int i = 1; i <= num; i++)
                    {
                        sum += i;
                    }
                    //输出结果
                    Console.WriteLine($"1-{num}的累加值是：{sum}");
                    Console.Write($"请输入一个正整数：");
                    userInput = Console.ReadLine();
                    //num不是正整数，要求重新输入
                }
                else
                {
                    Console.Write($"您的输入有误，请重新输入：");
                    userInput = Console.ReadLine();
                }
            }
            Console.WriteLine($"Bye!");
        }
    }
}
