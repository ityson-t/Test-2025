namespace IntegrationSystem
{
    internal interface ITool
    {
        string Name { get; }
        void Run();
    }

    internal class HelloTool : ITool
    {
        public string Name => "问候语";
        public void Run()
        {
            while (true)
            {
                Console.Write("请输入您的名字：");
                string userName = Console.ReadLine();
                if (string.IsNullOrEmpty(userName))
                    continue;
                Console.WriteLine($"您好：{userName}");
                break;
            }
        }
    }

    internal class AccumulatorTool : ITool
    {
        public string Name => "累加器";
        public void Run()
        {
            while (true)
            {
                Console.Write("请输入一个数字：");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int userNumber))
                {
                    int sum = 0;
                    if (userNumber > 0)
                    {
                        for (int i = 1; i <= userNumber; i++)
                            sum += i;
                    }
                    else
                    {
                        for (int i = 0; i >= userNumber; i--)
                            sum += i;
                    }
                    Console.WriteLine($"累加结果：{sum}");
                    break;
                }
                else
                {
                    Console.Write("您的输入有误，");
                    continue;
                }
            }
        }
    }

    internal class JudgmentTool : ITool
    {
        public string Name => "奇偶数判断";
        public void Run()
        {
            while (true)
            {
                Console.Write("请输入一个数字：");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int userNumber))
                {
                    string result = (userNumber % 2 == 0) ? "偶数" : "奇数";
                    Console.WriteLine($"{userNumber}是{result}");
                    break;
                }
                else
                {
                    Console.Write("您的输入有误：");
                    continue;
                }
            }
        }
    }

    internal class MultiplicationTool : ITool
    {
        public string Name => "乘法表";
        public void Run()
        {
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j}*{i}={i * j,2}  ");
                }
                Console.WriteLine();
            }
        }
    }

    internal class GuessTool : ITool
    {
        public string Name => "猜数字";
        public void Run()
        {
            Random r = new Random();
            int randomNumber = r.Next(1, 101);
            Console.Write("请输入一个数字：");
            int count = 1;
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int userNumber))
                {
                    if (userNumber == randomNumber)
                    {
                        Console.WriteLine($"恭喜！您用了{count}次猜对。");
                        break;
                    }
                    else
                    {
                        string compare = (userNumber > randomNumber ? "大了：" : "小了：");
                        Console.Write(compare);
                        count++;
                        continue;
                    }
                }
                else
                {
                    Console.Write("您的输入有误：");
                    continue;
                }
            }
        }
    }

    internal class BmiTool : ITool
    {
        public string Name => "BMI计算器";
        public void Run()
        {
            double height, weight;
            while (true)
            {
                Console.Write("请输入身高：");
                string userInput = Console.ReadLine();
                if (double.TryParse(userInput, out height) && height > 0)
                    break;
                else
                    Console.Write("您的输入有误：");
                continue;
            }
            while (true)
            {
                Console.Write("请输入体重：");
                string userInput = Console.ReadLine();
                if (double.TryParse(userInput, out weight) && weight > 0)
                    break;
                else
                    Console.Write("您的输入有误：");
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
        }
    }

    internal class ToolBox
    {
        private readonly List<ITool> tools = new()
        {
            new HelloTool(),
            new AccumulatorTool(),
            new JudgmentTool(),
            new MultiplicationTool(),
            new GuessTool(),
            new BmiTool()
        };

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("===欢迎使用DOS工具箱===");
                for (int i = 0; i < tools.Count; i++)
                {
                    Console.WriteLine($"{i + 1}、{tools[i].Name}");
                }
                Console.WriteLine($"{tools.Count + 1}、退出程序");
                Console.Write("请选择：");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int userSelect) && userSelect > 0 && userSelect <= tools.Count + 1)
                {
                    if (userSelect == tools.Count + 1)
                        return;
                    tools[userSelect - 1].Run();
                }
                else
                {
                    Console.WriteLine("输入有误，请重新选择：");
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            new ToolBox().Run();
        }
    }
}