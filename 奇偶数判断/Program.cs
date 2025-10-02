using System.Numerics;
using System.Xml;

namespace 奇偶数判断
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //输入一个整数，判断它是奇数还是偶数。输入 "exit" 时结束程序。
            //要求用户输入一个整数
            Console.Write($"请输入一个数字：");
            //声明变量userInput接收用户输入
            string userInput = Console.ReadLine();
            //如果用户输入不为exit继续进行判断
            while (userInput != "exit")
            {
                int num = 0;
                if (int.TryParse(userInput, out num))
                {
                    if(num == 0) 
                    { 
                        Console.WriteLine($"{num}，不是奇数也不是偶数");
                    }
                    else if (num % 2 == 0) 
                    {
                        Console.WriteLine($"{num},偶数");
                    }
                    else
                    {
                        Console.WriteLine($"{num},奇数");                        
                    }
                }
                else
                {
                    Console.Write($"您的输入有误，");
                    
                }
                Console.Write($"请输入一个数字：");
                userInput = Console.ReadLine();
            }
            Console.WriteLine($"Bye!");
        }
    }
}
