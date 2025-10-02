namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random ra=new Random();
            int r=ra.Next(1,101);
            int count = 1;
            Console.Write("请猜数字：");            
            while (true)
            {
                string userInput = Console.ReadLine();
                if (!int.TryParse(userInput,out int userNumber))
                {
                    Console.Write($"请输入数字：");
                    continue;
                }
                if (userNumber > r)
                {
                    Console.Write($"大了，再猜：");
                    count++;
                }
                else if (userNumber < r)
                {
                    Console.Write($"小了，再猜：");
                    count++;
                }
                else
                {
                    Console.WriteLine($"恭喜，猜对了，您用了{count}次猜对。");
                    break;
                }
            }
        }
    }
}
