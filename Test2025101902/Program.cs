using System.Diagnostics;
using System.Threading;

namespace Test2025101902
{
    interface IFeedable { public string Eat(); }
    interface ITrainable { public string Train(); }
    internal abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Animal(string name, int age) { Name = name; Age = age; }
        abstract public string MakeSound();
        abstract public string Move();
    }
    internal class Lion : Animal, IFeedable, ITrainable
    {
        public string Bread { get; set; }
        public Lion(string name, int age, string bread) : base(name, age) { Bread = bread; }
        public override string MakeSound() { return $"噢~~~鸣~~~"; }
        public override string Move() { return $"咻~咻~咻~~~"; }
        public string Eat() { return $"肉类和小动物"; }
        public string Train() { return $"跳火圈"; }
        public override string ToString() { return $"[{Bread}]{Name}走起路来{Move()},大叫起来{MakeSound()},会吃{Eat()},还会表演{Train()}。"; }
    }
    internal class Elephant : Animal, IFeedable
    {
        public string Bread { get; set; }
        public Elephant(string name, int age, string bread) : base(name, age) { Bread = bread; }
        public override string MakeSound() { return $"嗯~~~噢~~~"; }
        public override string Move() { return $"哐~哐~哐~~~"; }
        public string Eat() { return $"香蕉"; }
        public override string ToString() { return $"[{Bread}]{Name}走起路来{Move()},大叫起来{MakeSound()},会吃{Eat()}。"; }
    }
    internal class Penguin : Animal, IFeedable, ITrainable
    {
        public string Bread { get; set; }
        public Penguin(string name, int age, string bread) : base(name, age) { Bread = bread; }
        public override string MakeSound() { return $"嘎~~~嘎~~~"; }
        public override string Move() { return $"叭叽~叭叽~叭叽~~~"; }
        public string Eat() { return $"小鱼"; }
        public string Train() { return $"骑小车"; }
        public override string ToString() { return $"[{Bread}]{Name}走起路来{Move()},大叫起来{MakeSound()},会吃{Eat()},还会表演{Train()}。"; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion($"杰德", 5, "美洲狮");
            Elephant elephant = new Elephant("大鼻",16, "非洲象");
            Penguin penguin=new Penguin("肉球",7,"南极企鹅");
            Console.WriteLine(lion);
            Console.WriteLine(elephant);
            Console.WriteLine(penguin);
        }
    }
}
