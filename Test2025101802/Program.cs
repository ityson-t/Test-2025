using System.Diagnostics.Contracts;

namespace Test2025101802
{
    //    Day 3：方法与参数（复习调用逻辑）

    //目标：掌握方法定义、返回值、参数传递。

    //任务内容

    //定义一个类 MathHelper：

    //Add(int a, int b)

    //IsEven(int n)

    //GetAverage(List<int> list)

    //在主程序中调用这些方法，输出结果。

    //练习命名方法 → 匿名方法 → Lambda 表达式的写法转换。
    delegate void IntHandler(int x, int y);
    internal class MathHelper
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
        public void Add(int a, int b)
        {
            num1 = a;
            num2 = b;
        }
        public bool IsEven(int n)
        {
            return n % 2 == 0 ? true : false;
        }
        public int GetAverage(List<int> list)
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum / list.Count;
        }
        public override string ToString()
        {
            return $"n1={num1},n2={num2}";
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            IntHandler intH;
            List<int> intList = [83105, 34, 462, 891, 2589, 32, 4890, 7659, 2345, 52];
            MathHelper mH = new MathHelper();

            MathHelper mL = new MathHelper();
            mH.Add(134, 645);
            intH = delegate (int x, int y) { mL.num1 = x; mL.num2 = y; };
            intH(111, 222);
            Console.WriteLine(mH);
            Console.WriteLine(mL);
            MathHelper mK = new MathHelper();
            intH = (x, y) => { mK.num1 = x; mK.num2 = y; };
            intH(222, 333);
            Console.WriteLine(mK);
            MathHelper mJ = new MathHelper();
            Action<int,int> f = (x, y) => { mJ.num1 = x;mJ.num2 = y; };
            f(333, 444);
            Console.WriteLine(mJ);
            Console.WriteLine($"{mH.num1}是不是偶数：{(mH.IsEven(mH.num1) ? "是" : "不是")}");
            Console.WriteLine($"集合平均值：{mH.GetAverage(intList)}");
        }
    }
}
