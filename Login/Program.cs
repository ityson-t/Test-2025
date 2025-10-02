namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            while (count < 3)
            {
                Console.Write($"请输入用户名：");
                string userInputName = Console.ReadLine();
                Console.Write($"请输入密码：");
                string userInputPassword = Console.ReadLine();
                if (userInputName == "admin" && userInputPassword == "1234")
                {
                    Console.WriteLine($"登录成功！");
                    return;
                }
                count++;
                Console.WriteLine($"输入错误，请重新输入：");

            }
            Console.WriteLine($"连续3次输入错误，账号锁定。");

        }
    }
}
