namespace 乘法表
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j}*{i}={i*j,2}  ");
                }
                Console.WriteLine();
            }
        }
    }
}
