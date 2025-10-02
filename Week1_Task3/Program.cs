namespace Week1_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double h, w;
            while (true)
            {
                Console.Write("身高：");
                string height = Console.ReadLine();
                if (!double.TryParse(height, out h))
                {
                    Console.Write($"输入错误：");
                    continue;
                }
                else { break; }
            }
            while (true)
            {
                Console.Write($"体重：");
                string weight = Console.ReadLine();
                if (!double.TryParse(weight, out w))
                {
                    Console.Write($"输入错误：");
                    continue;
                }else { break; }
            }
            double dMI = w / (h * h);
            string strDMI = "";
            if (dMI < 18.5)
            {
                strDMI = "偏瘦";
            }
            else if (dMI >= 18.5 && dMI < 24)
            {
                strDMI = "正常";
            }
            else if (dMI >= 24 && dMI < 28)
            {
                strDMI = "超重";
            }
            else { strDMI = "肥胖"; }
            Console.WriteLine($"您的DMI是：{dMI:f2}\n属于{strDMI}范围。");
            return;

        }
    }
}
