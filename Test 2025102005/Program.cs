using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Test_2025102005
{
    interface IHasName { string Name { get; } }
    internal class Student : IHasName
    {
        double chinese;
        double math;
        double english;
        public event EventHandler<double> AverageChanged;
        public string Name { get; set; }
        public int Id { get; init; }
        public double Chinese
        {
            get => chinese;
            set
            {
                this.chinese = value;
                AverageChanged?.Invoke(this, this.Average);
            }
        }
        public double Math
        {
            get => math;
            set
            {
                this.math = value;
                AverageChanged?.Invoke(this, this.Average);
            }
        }
        public double English
        {
            get => english;
            set
            {
                this.english = value;
                AverageChanged?.Invoke(this, this.Average);
            }
        }
        public double Average
        {
            get => (Chinese + Math + English) / 3;
        }
        public string Level
        {
            get => Average switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                _ => "D"
            };

        }
        public static int StudentCount { get; private set; }
        public override string ToString()
        {
            return $"姓名：{Name}，学号：{Id}，语文：{Chinese}，数学：{Math}，英语：{English}，平均成绩：{Average:f2}，等级：{Level}。\n学生总数：{StudentCount}";
        }
        public Student(string name, int id, double chinese, double math, double english)
        {
            Name = name;
            Id = id;
            Chinese = chinese;
            Math = math;
            English = english;
            StudentCount++;
        }
    }
    internal class GraduateStudent : Student
    {
        public string ThesisTitle { get; set; }
        public GraduateStudent(string name, int id, double chinese, double math, double english, string thesisTitle) : base(name, id, chinese, math, english)
        {
            ThesisTitle = thesisTitle;
            GraduateStudentCount++;
        }
        public static int GraduateStudentCount { get; private set; }
        public override string ToString()
        {
            return $"姓名：{Name}，学号：{Id}，研究学科：{ThesisTitle}，语文：{Chinese}，数学：{Math}，英语：{English}，平均成绩：{Average:f2}，等级：{Level}。\n研究生总数：{GraduateStudentCount}";
        }
    }
    internal class Teacher<T> : IHasName where T : IHasName
    {
        public string Name { get; }
        public int Id { get; }
        public List<T> Students = [];
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Students.Count)
                    throw new IndexOutOfRangeException("超出索引范围");
                return Students[index];
            }
        }
        public T this[string name]
        {
            get
            {
                return Students.FirstOrDefault(x => x.Name == name) ?? throw new KeyNotFoundException($"未找到学生：{name}");
            }
        }
    }
    internal class Program
    {
        static void Main()
        {
            Teacher<Student> student = new();
            Teacher<GraduateStudent> graduateStudent = new();
            //增加大学生
            student.Students.Add(new Student("张一元", 1001, 98, 97, 99));
            student.Students.Add(new Student("李二狗", 1002, 96, 93, 92));
            student.Students.Add(new Student("何珠", 1003, 31, 57, 77));
            //增加研究生
            graduateStudent.Students.Add(new GraduateStudent("李何", 1004, 78, 88, 69, "计算机科学"));
            graduateStudent.Students.Add(new GraduateStudent("姚玉", 1005, 88, 78, 99, "计算机科学"));
            graduateStudent.Students.Add(new GraduateStudent("刘工", 1006, 58, 38, 69, "计算机科学"));
            //索引器按姓名查找修改
            student["张一元"].English = 60;
            graduateStudent["刘工"].Chinese = 87;
            //按学号查找
            student.Students.FindAll(x => x.Id == 1002).ForEach(x => Console.WriteLine(x));
            graduateStudent.Students.FindAll(x => x.Id == 1004).ForEach(x => Console.WriteLine(x));
            //索引器按索引查找修改
            student[0].Math = 77;
            //查找所有学生
            student.Students.ForEach(x => Console.WriteLine(x));
            graduateStudent.Students.ForEach(x => Console.WriteLine(x));
            //删除学生
            student.Students.RemoveAt(0);
            graduateStudent.Students.RemoveAt(0);
            //查找所有学生
            student.Students.ForEach(x => Console.WriteLine(x));
            graduateStudent.Students.ForEach(x => Console.WriteLine(x));
            //平均成绩
            Console.WriteLine($"{student.Students.Average(x => x.Average):f2}");
            Console.WriteLine($"{graduateStudent.Students.Average(x => x.Average).ToString():f2}");
            //最高最低分
            Console.WriteLine($"{student.Students.Max(x => x.Average):f2}");
            Console.WriteLine($"{graduateStudent.Students.Min(x => x.Average):f2}");
            //按等级统计
            student.Students.FindAll(x => x.Level == "A").ForEach(x => Console.WriteLine(x));
            //平均分前N名
            var avgN = student.Students.OrderByDescending(x => x.Average).Take(2);
            foreach (var item in avgN)
            {
                Console.WriteLine(item);
            }
            Student er = student["李二狗"];
            er.AverageChanged += (s, e) => { Console.WriteLine($"平均分变了{e}"); };
            student["李二狗"].Math = Convert.ToDouble(Console.ReadLine());
        }
    }
}
