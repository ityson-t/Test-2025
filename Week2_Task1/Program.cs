namespace Week2_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number1, number2, result;
            string userOperator;
            while (true)
            {
                Console.Write($"请输入第一个数字：");
                string firstNumber = Console.ReadLine();
                if (!double.TryParse(firstNumber, out number1))
                {
                    Console.Write($"输入错误，");
                    continue;
                }
                else { break; }
            }
            while (true)
            {
                Console.Write($"请输入运算符：");
                userOperator = Console.ReadLine();
                if (userOperator == "+" || userOperator == "-" || userOperator == "*" || userOperator == "/")
                {
                    break;
                }
                else
                {
                    Console.Write($"输入错误，");
                    continue;
                }
            }
            while (true)
            {
                Console.Write($"请输入第二个数字：");
                string secondNumber = Console.ReadLine();
                if (!double.TryParse(secondNumber, out number2))
                {
                    Console.Write($"输入错误，");
                    continue;
                }
                else if (userOperator == "/" && number2 == 0)
                {
                    Console.Write($"除数不能为0，");
                    continue;
                }
                else { break; }
            }
            switch (userOperator)
            {
                case "+": result = number1 + number2; break;
                case "-": result = number1 - number2; break;
                case "*": result = number1 * number2; break;
                case "/": result = number1 / number2; break;
                default: result = 0; break;
            }
            Console.WriteLine($"{number1}{userOperator}{number2}={result:f2}");
        }
    }
}
