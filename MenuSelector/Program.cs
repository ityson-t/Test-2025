namespace MenuSelector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //列出菜单
                Console.WriteLine($"请做如下选择：\n1、打招呼\n2、计算平方\n3、退出");
                //声明变量接收用户输入
                string userSelect = Console.ReadLine();
                //声明int类型变量用于接收转换过的用户输入
                if (!int.TryParse(userSelect, out int num)) 
                {
                    Console.WriteLine($"选择错误，请重新选择：");
                    continue;
                }
                switch (num)
                {
                    case 1:
                        Console.WriteLine($"您好！");
                        break;
                    case 2:
                        Console.Write($"请输入一个数字：");
                        string userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int userNum))
                        {
                            Console.WriteLine($"{userNum}的平方是：{userNum * userNum}");
                        }
                        else
                        {
                            Console.WriteLine($"输入错误。");
                        }
                        break;
                    case 3:
                        Console.WriteLine($"Bye!");
                        return;
                    default:
                        Console.WriteLine($"无效选择");
                        break;
                }
            }

        }
    }
}
