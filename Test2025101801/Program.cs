namespace Test2025101801
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = [83105, 34, 462, 891, 2589, 32, 4890, 7659, 2345, 52];
            Console.Write($"foreach输出所有数字：");
            foreach (var item in intList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.Write("偶数");
            foreach (var item in intList)
            {
                if (item % 2 == 0)
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();
            int avg1 = 0; int count = 0;
            foreach (var item in intList)
            {
                if (item % 2 == 1)
                {
                    avg1 += item;
                    count++;
                }
            }
            Console.Write($"奇数平均值：{avg1 / count}");
            Console.WriteLine();
            Console.Write($"for输出所有数字：");
            for (int i = 0; i < intList.Count; i++)
            {
                Console.Write($"{intList[i]} ");
            }
            Console.WriteLine();
            Console.Write("偶数");
            int avg2 = 0; int count1 = 0;
            for (int i = 0; i < intList.Count; i++)
            {
                if (intList[i] % 2 == 01)
                    Console.Write($"{intList[i]} ");
            }
            Console.WriteLine();
            for (int i = 0; i < intList.Count; i++)
            {
                if (intList[i] % 2 == 1)
                {
                    avg2 += intList[i];
                    count1++;
                }
            }
            Console.Write($"奇数平均值：{avg2 / count1}");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"list foreach输出所有数字：");
            intList.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
            Console.Write("偶数");
            var x = intList.FindAll(x => x % 2 == 0);
            x.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
            var y = intList.FindAll(x => x % 2 == 1);
            int avg3 = 0;int count3 = 0;
            foreach (var item in y)
            {
                avg3 += item;
                count3++;
            }
            Console.WriteLine($"奇数平均：{avg3/count3}");
        }
    }
}
