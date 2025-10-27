using System.Net.Sockets;
using System.Threading.Channels;

namespace Test20251018
{
    internal static class UserInputHelper
    {
        public static T InputHelper<T>(string prompt, Func<string, (bool success, T value)> parseFunc, Predicate<T> condtion)
        {
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                var (success, value) = parseFunc(userInput);
                if (success && condtion(value))
                    return value;
                Console.Write("输入错误：");
            }
        }
    }
    internal class Program
    {
        static void Main()
        {
            double chinese = UserInputHelper.InputHelper("请输入语文的成绩（1-100）：", x => (double.TryParse(x, out var v), v), v => v >= 0 && v <= 100);
            double math = UserInputHelper.InputHelper("请输入数学的成绩（1-100）：", x => (double.TryParse(x, out var v), v), v => v >= 0 && v <= 100);
            double english = UserInputHelper.InputHelper("请输入英语的成绩（1-100）：", x => (double.TryParse(x, out var v), v), v => v >= 0 && v <= 100);
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
    }
}
