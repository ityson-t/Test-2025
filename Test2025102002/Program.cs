using System.Security.Cryptography.X509Certificates;

namespace Test2025102002
{
    delegate void Balance(decimal amount);
    internal class BankAccount : EventArgs
    {
        public event Balance BalanceChanged;
        public string Name { get; set; }
        public decimal Balance { get; set; } = 0;
        public BankAccount(string name) { Name = name; }
        public void Deposit(decimal amount)
        {
            Balance += amount;
            BalanceChanged?.Invoke(Balance);
        }
        public void Withdraw(decimal amount)
        {
            while (true)
            {

                if (amount > Balance)
                {
                    Console.WriteLine($"余额不足。");
                    break;
                }
                else
                {
                    Balance -= amount;
                    BalanceChanged?.Invoke(Balance);
                    break;
                }
            }
        }
        public override string ToString()
        {
            return $"账户名：{Name}---余额：{Balance}";
        }
    }
    internal class Logger
    {
        public List<string> log = new List<string>();
        public Logger(BankAccount bankAccount)
        {
            bankAccount.BalanceChanged += Add;
        }
        public void Add(decimal balance)
        {
            log.Add($"{DateTime.Now}:{balance}");
        }
    }
    internal class Alarm
    {
        public Alarm(BankAccount bankAccount)
        {
            bankAccount.BalanceChanged += LowAlarm;
        }
        public void LowAlarm(decimal balance)
        {
            if (balance < 100)
                Console.WriteLine($"当前余额{balance},低余额预警...");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount("新开户");
            Alarm alarm = new Alarm(bankAccount);
            Logger logger = new Logger(bankAccount);
            while (true)
            {
                Console.Write($"1存2取3显4志5退：");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.Write($"存款金额：");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                        bankAccount.Deposit(amount);
                        break;
                    case 2:
                        Console.Write($"取款金额：");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        bankAccount.Withdraw(amount);
                        break;
                    case 3:
                        Console.WriteLine(bankAccount);
                        break;
                    case 4:
                        logger.log.ForEach(x => Console.WriteLine(x));
                        break;
                    case 5:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
