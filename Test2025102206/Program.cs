using System.Net;

namespace Test2025102206
{
    internal class MyDownloadString
    {
        public void DoRun()
        {
            Task<int> t = CountCharactersAsync("https://www.msn.com", "https://www.nga.cn");
            Console.WriteLine($"任务 {(t.IsCompleted?"已":"未")} 完成");
            Console.WriteLine($"结果 {t.Result}");
        }
        private async Task<int> CountCharactersAsync(string site1, string site2)
        {
            WebClient wc1 = new();
            WebClient wc2 = new();
            Task<string> t1 = wc1.DownloadStringTaskAsync(new Uri(site1));
            Task<string> t2 = wc2.DownloadStringTaskAsync(new Uri(site2));
            List<Task<string>> tasks = new();
            tasks.Add(t1);
            tasks.Add(t2);
            await Task.WhenAll(tasks);
            Console.WriteLine($"    CCA:    T1 {(t1.IsCompleted ? "" : "Not")} Finished.");
            Console.WriteLine($"    CCA:    T2 {(t2.IsCompleted ? "" : "Not")} Finished.");
            return t1.IsCompleted ? t1.Result.Length : t2.Result.Length;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDownloadString ds = new();
            ds.DoRun();
        }
    }
}
