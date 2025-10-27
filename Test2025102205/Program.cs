namespace Test2025102205
{
    internal class DoAsyncStuff
    {
        private static int GetSum(int i1, int i2) { return i1 + i2; }
        public static async ValueTask<int> CalculateSumAsync(int i1, int i2)
        {
            if (i1 == 0)
            {
                return i2;
            }
            int sum = await Task<int>.Run(() => GetSum(i1, i2));
            return sum;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ValueTask<int> value = DoAsyncStuff.CalculateSumAsync(0, 9);
            Console.WriteLine(value.Result);
            value = DoAsyncStuff.CalculateSumAsync(8, 2);
            Console.WriteLine(value.Result);
        }
    }
}
