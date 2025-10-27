namespace Test2025102203
{
    internal static class DoAsyncStuff
    {
        public async static Task CalculateSumAsync(int i1, int i2)
        {
            int value = await Task.Run(() =>  GetSum(i1, i2));
            Console.WriteLine($"异步线程已完成");
        }
        private static int GetSum(int i1, int i2) { return i1 + i2; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread.Sleep(200);
            Task someTask = DoAsyncStuff.CalculateSumAsync(7, 8);
        }
    }
}
