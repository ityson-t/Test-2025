using System.Net.Sockets;
using System.Threading.Channels;

namespace Test20251018
{
    internal static class UserInputHelper
    {
        public static bool CheckDoubleInput(string input, out double doubleResult)
        {
            if (double.TryParse(input, out double result))
            {
                doubleResult = result;
                return true;
            }
            else
            {
                doubleResult = 0;
                return false;
            }
        }
        public static bool CheckScope(double input, double min, double max)
        {
            return input >= min && input <= max;
        }
    }
    internal class Program
    {
        static void Main()
        {
            Func<string, double, double, double> inputHelper = DoubleInputHelper;
            double chinese = inputHelper("请输入中文的成绩（1-100）：", 0, 100);
            double math = inputHelper("请输入数学的成绩（1-100）：", 0, 100);
            double english = inputHelper("请输入英语成绩（1-100）：", 0, 100);
            double sumScore = chinese + math + english;
            double avgScore = (chinese + math + english) / 3;
            Console.WriteLine();
            Console.WriteLine($"您的平均成绩是：{avgScore:f2},您的评分等级通过if...else方法的结果是：{GetGradeWithIfElse(avgScore)}");
            Console.WriteLine();
            Console.WriteLine($"您的平均成绩是：{avgScore:f2},您的评分等级通过switch方法的结果是：{GetGradeWithSwitch(avgScore)}");
            Console.WriteLine();
            Console.WriteLine($"您的平均成绩是：{avgScore:f2},您的评分等级通过if...else方法的结果是：{GetGradeWithTernaryExpression(avgScore)}");
        }
        static string GetGradeWithIfElse(double score)
        {
            if (score <= 100 && score >= 90)
            {
                return "A";
            }
            else if (score < 90 && score >= 80)
            {
                return "B";
            }
            else if (score < 80 && score >= 70)
            {
                return "C";
            }
            else
            {
                return "D";
            }
        }
        static string GetGradeWithSwitch(double score) =>
            score switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                _ => "D"
            };
        static string GetGradeWithTernaryExpression(double score)
        {
            return score >= 90 ? "A" :
                score >= 80 ? "B" :
                score >= 70 ? "C" : "D";
        }
        static double DoubleInputHelper(string input, double min, double max)
        {
            while (true)
            {
                Console.Write(input);
                if (UserInputHelper.CheckDoubleInput(Console.ReadLine(), out double result) && UserInputHelper.CheckScope(result, min, max))
                    return result;
                Console.Write("输入错误：");
            }
        }
    }
}
