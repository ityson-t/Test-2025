using System.Threading.Tasks.Sources;
using System.Xml.Linq;

namespace Test_2025
{
    public class Student
    {

        public double[] Score { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Student(string name,int age, double[] score)
        {
            Age = age;
            Name = name;
            Score = score;
        }
        public double AverageScore()
        {
            double totalScore = 0;
            foreach (var scoreItem in Score) { totalScore += scoreItem; }
            return totalScore / Score.Length;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new("张一元", 16, new double[] { 85, 90, 78, 88, 92 });
            Console.WriteLine($"姓名：{s1.Name}");
            Console.WriteLine($"年龄：{s1.Age}");
            Console.Write($"成绩：");
            for (int i = 0; i < s1.Score.Length; i++)
            {
                Console.Write($"{s1.Score[i]}");
                if (i<s1.Score.Length-1)
                {
                    Console.Write($",");
                }
            }
            Console.WriteLine($"\n平均成绩：{s1.AverageScore():F2}");
        }
    }
}
