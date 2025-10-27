using System.Net.NetworkInformation;

namespace Test2025102202
{
    internal static class DoAsyncStuff
    {
        public static async Task<int> CalculateSumAsync(int i1,int i2)
        {
            return await Task.Run(() => GetSum(i1, i2));            
        }
        private static int GetSum(int i1, int i2)
        {
            return i1+i2;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<int> value = DoAsyncStuff.CalculateSumAsync(4, 6);
            Console.WriteLine(value.Result);
        }
    }
}
