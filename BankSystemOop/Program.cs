namespace BankSystemOop
{
    internal class UserInputHelper
    {
        public static int CheckSelect(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int userSelect) && (userSelect >= 1 && userSelect <= 4))
                {
                    return userSelect;
                }
                else
                {
                    Console.Write("输入错误，");
                    continue;
                }
            }
        }
        public static double CheckAmount(string prompt)
        {
            while (true)
            {
                Console.Write($"请输入{prompt}金额：");
                string amount = Console.ReadLine();
                if (double.TryParse(amount, out double amountSelect))
                {
                    return amountSelect;
                }
                else
                {
                    Console.Write($"输入错误，");
                    continue;
                }
            }
        }
    }
    internal class BankAccount
    {
        string accountName;
        double balance;
        public BankAccount(string name, double initialBalance)
        {
            accountName = name;
            balance = initialBalance;
        }
        public double Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("存款金额必须大于0");
            }
            balance += amount;
            return balance;
        }
        public double Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("取款金额必须大于0");
            }
            if (amount > balance)
            {
                throw new ArgumentException("余额不足");
            }
            balance -= amount;
            return balance;
        }
        public string GetAccountStatus()
        {
            return $"账户名：{accountName}，余额：{balance}";
        }

    }
    internal class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount("张三", 1000);

            while (true)
            {
                Console.Write($"===银行账户模拟器===\n1、存款\n2、取款\n3、查看余额\n4、退出\n");
                switch (UserInputHelper.CheckSelect($"请选择："))
                {
                    case 1:
                        try
                        {
                            account.Deposit(UserInputHelper.CheckAmount("存款"));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        break;
                    case 2:
                        try
                        {
                            account.Withdraw(UserInputHelper.CheckAmount($"取款"));
                        }
                        catch (ArgumentException ex)
                        {

                            Console.WriteLine($"{ex.Message}");
                        }
                        break;
                    case 3:
                        Console.WriteLine($"{account.GetAccountStatus()}");
                        break;
                    case 4:
                        return;
                    default:
                        break;
                }
                
            }

        }
    }
}
