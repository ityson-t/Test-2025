namespace BankSystem
{
    internal class Program
    {
        static void Main()
        {
            string name = "张三";
            double balance = 1000;
            while (true)
            {
                Console.Write($"===银行账户模拟器===\n1、存款\n2、取款\n3、查看余额\n4、退出\n请选择：");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int userSelect) && (userSelect >= 1 && userSelect <= 4))
                {
                    switch (userSelect)
                    {
                        case 1:
                            while (true)
                            {
                                Console.Write($"请输入存款金额：");
                                string amount = Console.ReadLine();
                                if (double.TryParse(amount, out double amountSelect))
                                {
                                    try
                                    {
                                        balance = Deposit(balance, amountSelect);
                                        Console.WriteLine($"存款成功！");

                                    }
                                    catch (ArgumentException ex)
                                    {

                                        Console.WriteLine($"{ex.Message}");
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.Write($"输入错误，");
                                    continue;
                                }
                            }
                            break;
                        case 2:
                            while (true)
                            {
                                Console.Write($"请输入取款金额：");
                                string amount = Console.ReadLine();
                                if (double.TryParse(amount, out double amountSelect))
                                {
                                    try
                                    {
                                        balance = Withdraw(balance, amountSelect);
                                        Console.WriteLine($"取款成功！");

                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine($"{ex.Message}");
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.Write($"输入错误，");
                                    continue;
                                }
                            }
                            break;
                        case 3:
                            Console.WriteLine(GetAccountSummary(name, balance));
                            break;
                        case 4:
                            Console.WriteLine($"再见！");
                            return;
                        default:
                            break;
                    }
                }
                else { Console.Write($"选择错误："); continue; }
            }

        }
        static double Deposit(double balance, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"存款金额必须大于0。");
            }
            else
            {
                balance += amount;

                return balance;
            }
        }
        static double Withdraw(double balance, double amount)
        {
            if (balance < amount)
            {
                //return balance;
                throw new ArgumentException($"余额不足。");
            }
            else if (amount <= 0)
            {
                // return balance;
                throw new ArgumentException($"取款金额不能小于0。");
            }
            else
            {
                balance -= amount;
                return balance;
            }
        }
        static string GetAccountSummary(string account, double balance)
        {
            return $"账户：{account} 余额：¥{balance:f2}";
        }
    }
}
