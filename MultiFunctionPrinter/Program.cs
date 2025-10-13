namespace MultiFunctionPrinter
{
    interface IPrinter
    {
        void Print(string document);
    }
    interface IScanner
    {
        string Scan();
    }
    interface IFax
    {
        void Fax(string document, string phoneNumber);
    }
    interface ICopier : IPrinter, IScanner
    {
        void Copy();
    }
    internal class MultiFunctionPrinter : ICopier, IFax
    {
        public void Fax(string document, string phoneNumber)
        {
            Console.WriteLine($"正在传真到 {phoneNumber}：{document}");
        }
        public void Print(string document)
        {
            Console.WriteLine($"正在打印：{document}");
        }
        public string Scan()
        {
            Console.WriteLine("正在扫描文档...");
            return "===扫描的文档内容===";
        }
        public void Copy()
        {
            string scannedContent = Scan();
            Print($"[副本] {scannedContent}");
        }
    }
    internal class Program
    {
        static void Main()
        {
            MultiFunctionPrinter mfp = new();
            IPrinter printer = mfp;
            printer.Print("===打印测试页===");
            Console.WriteLine();
            IScanner scanner = mfp;
            Console.WriteLine(scanner.Scan()); 
            Console.WriteLine();
            IFax fax = mfp;
            fax.Fax("===传真文档内容===", "123-456-7890");
            Console.WriteLine();
            ICopier copier = mfp;
            copier.Copy();
        }
    }
}
