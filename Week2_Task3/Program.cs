namespace Week2_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一段文字：");
            string userInput = Console.ReadLine();
            Console.WriteLine($"字符总数：{userInput.Length}");
            int charCount = 0;
            bool isDig=false; 
            foreach (var item in userInput)
            {
                if (char.IsLetter(item))
                {
                    charCount++;
                }
                if (char.IsDigit(item))
                {
                    isDig = true;
                }
            }
            Console.WriteLine($"字母数量：{charCount}");
            Console.WriteLine($"是否包含数字：{(isDig?"是":"否")}");
            Console.WriteLine($"大写形式：{userInput.ToUpper()}");
            Console.WriteLine($"前5个字符是：{userInput.Substring(0, Math.Min(5, userInput.Length))}");
        }
    }
}
