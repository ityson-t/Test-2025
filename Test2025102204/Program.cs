namespace Test2025102204
{
    internal static class DoAsyncStuff
    {
        public static async void CalculateSumAsync(int i1,int i2)
        {
            int value = await Task.Run(() => GetSum(i1, i2));
            Console.WriteLine(value);
        }
        private static int GetSum(int i1,int i2) { return  i1 + i2; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DoAsyncStuff.CalculateSumAsync(2, 8);
            Thread.Sleep(200);
            Console.WriteLine("程序退出");
        }
    }
}
