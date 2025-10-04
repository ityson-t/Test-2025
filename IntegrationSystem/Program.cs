namespace IntegrationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //声明变量存储用户输入
                string userInput;
                //展示菜单
                Console.WriteLine($"===欢迎使用DOS工具箱===\n请选择您需要的工具\n1、问候语\n2、累加器\n3、奇偶数判断\n4、乘法表\n5、猜数字\n6、BMI计算器\n7、退出程序");
                //接收并检查用户输入
                string userSelect = Console.ReadLine();
                switch (userSelect)
                {
                    case "1":
                        while (true)
                        {
                            Console.Write($"请输入您的名字：");
                            string userName = Console.ReadLine();
                            if (userName == "")
                                continue;
                            else
                                Console.WriteLine($"您好：{userName}");
                            break;
                        }
                        break;
                    case "2":
                        while (true)
                        {
                            Console.Write($"请输入一个数字：");
                            userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out int userNumber))
                            {
                                int sum = 0;
                                if (userNumber > 0)
                                {
                                    for (int i = 1; i <= userNumber; i++)
                                    {
                                        sum += i;
                                    }
                                    Console.WriteLine($"累加结果：{sum}");
                                    break;
                                }
                                else
                                {
                                    for (int i = 0; i >= userNumber; i--)
                                    {
                                        sum += i;
                                    }
                                    Console.WriteLine($"累加结果：{sum}");
                                    break;
                                }
                            }
                            else
                            {
                                Console.Write($"您的输入有误，");
                                continue;
                            }
                        }
                        break;
                    case "3":
                        while (true)
                        {
                            Console.Write($"请输入一个数字：");
                            userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out int userNumber))
                            {
                                string result = ((userNumber % 2 == 0) ? "偶数" : "奇数");
                                Console.WriteLine($"{userNumber}是{result}");
                                break;
                            }
                            else
                            {
                                Console.Write($"您的输入有误：");
                                continue;
                            }
                        }
                        break;
                    case "4":
                        for (int i = 1; i <= 9; i++)
                        {
                            for (int j = 1; j <= i; j++)
                            {
                                Console.Write($"{j}*{i}={i * j,2}  ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "5":
                        Random r = new Random();
                        int randomNumber = r.Next(1, 101);
                        Console.Write($"请输入一个数字：");
                        int count = 1;
                        while (true)
                        {
                            userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out int userNumber))
                            {
                                if (userNumber==randomNumber)
                                {
                                    Console.WriteLine($"恭喜！您用了{count}次猜对。");
                                    break;
                                }
                                else
                                {
                                    string compare = (userNumber>randomNumber?"大了：":"小了：");
                                    Console.Write($"{compare}");
                                    count++;
                                    continue;
                                }
                            }
                            else
                            {
                                Console.Write($"您的输入有误：");
                                continue;
                            }
                        }
                        break;
                    case "6":
                        double height, weight;
                        while (true)
                        {
                            Console.Write($"请输入身高：");
                            userInput= Console.ReadLine();
                            if (double.TryParse(userInput, out height)&&height>0)
                                break;
                            else
                                Console.Write($"您的输入有误：");
                            continue;
                        } 
                        while (true)
                        {
                            Console.Write($"请输入体重：");
                            userInput = Console.ReadLine();
                            if (double.TryParse(userInput, out weight) && weight > 0)
                                break;
                            else
                                Console.Write($"您的输入有误：");
                            continue;
                        }
                        double bmi = weight / (height * height);
                        string userBmi = "";
                        if (bmi < 18.5)
                            userBmi = "偏瘦";
                        else if (bmi >= 18.5 && bmi < 24)
                            userBmi = "正常";
                        else if (bmi >= 24 && bmi < 28)
                            userBmi = "偏胖";
                        else
                            userBmi = "肥胖";
                        Console.WriteLine($"您的BMI值是：{bmi:f2}；属于{userBmi}范围。");
                            break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine($"您的选择有误，请重新选择：");
                        continue;
                }
            }
        }
    }
}
