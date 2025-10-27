using System.Threading;
using System.Xml.Linq;

namespace Test2025101901
{
    internal class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Animal(string name, int age) { Name = name; Age = age; }
        virtual public string MakeSound()
        {
            return "动物叫...";
        }
        public override string ToString()
        {
            return $"{Name}现在{Age}岁，叫起来是{MakeSound()}";
        }
    }
    internal class Dog : Animal
    {
        public string Bread { get; set; }
        public Dog(string name, int age, string bread) : base(name, age) { Bread = bread; }
        public override string MakeSound() { return "汪...汪汪..."; }
        public override string ToString() { return $"[{Bread}:]{Name}现在{Age}岁，叫起来是{MakeSound()}"; }
    }
    internal class Cat : Animal
    {
        public string Color { get; set; }
        public Cat(string name, int age, string color) : base(name, age) { Color = color; }

        public override string MakeSound() { return "喵~喵喵~~~"; }
        public override string ToString() { return $"[{Color}小猫:]{Name}现在{Age}岁，叫起来是{MakeSound()}"; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog tuDog = new Dog("大黄", 3, "中华田园犬");
            Console.WriteLine(tuDog);
            Dog deMu = new Dog("哮天", 5, "德国牧羊犬");
            Console.WriteLine(deMu);
            Cat liHua = new Cat("土匪", 2, "三花");
            Console.WriteLine(liHua);
            Cat mianYin = new Cat("公主", 3, "雪白");
            Console.WriteLine(mianYin);
            Animal baseDog =(Animal) deMu;
            Console.WriteLine(baseDog);
            Animal baseCat = mianYin;
            Console.WriteLine(baseCat);
            Animal taiDi = new Dog("日天", 3, "泰迪");
            Console.WriteLine(taiDi);
            Animal yingDuan = new Cat("贱贱",2,"黑色");
            Console.WriteLine(yingDuan);
        }
    }
}
