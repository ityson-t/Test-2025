using System.Diagnostics;
using System.Net;

namespace Test2025102201
{
    internal class MyDownloadString
    {
        Stopwatch sw = new();
        public void DoRun()
        {
            const int LargeNumber = 6_000_000;
            sw.Start();
            Task<int> t1 = CountCharactersAsync(1, "http://www.baidu.com");
            Task<int> t2 = CountCharactersAsync(2, "https://www.msn.cn/zh-cn?ocid=BingHp01&cvid=68f856f0d5b2475bbc1a2c4ccb41fecc");
            CountToAlargeNumber(1, LargeNumber);
            CountToAlargeNumber(2, LargeNumber);
            CountToAlargeNumber(3, LargeNumber);
            CountToAlargeNumber(4, LargeNumber);
            Console.WriteLine($"来自 http://www.microsoft.com 的字符         ：{t1.Result}");
            Console.WriteLine($"来自 http://www.illustratedcsharp.com 的字符 :{t2.Result}");
        }
        private async Task<int> CountCharactersAsync(int id, string uriString)
        {
            WebClient wc = new();
            Console.WriteLine($"开始通话{id}    :    {sw.ElapsedMilliseconds,4:NO} ms");
            string result = await wc.DownloadStringTaskAsync(new Uri(uriString));
            Console.WriteLine($"{id}通话完成:    {sw.Elapsed.TotalMilliseconds,4:NO} ms");
            return result.Length;
        }
        private void CountToAlargeNumber(int id, int value)
        {
            for (long i = 0; i < value; i++) ;
            Console.WriteLine($"结束记数：{id}    :    {sw.Elapsed.TotalMilliseconds,4:NO} ms");
        }
    }
    internal class Program
    {
        static void Main()
        {
            MyDownloadString ds = new MyDownloadString();
            ds.DoRun();
        }
    }
}
