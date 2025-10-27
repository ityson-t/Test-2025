namespace Test2025101903
{
    interface IPet
    {
        public string Speak();
        public string Eat();
    }
    interface ITrainable
    {
        public string Train();
    }
    abstract internal class Pet : IPet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Bread { get; set; }
        public Pet(string name, int age, string bread)
        {
            Name = name;
            Age = age;
            Bread = bread;
        }
        abstract public string Speak();
        abstract public string Eat();
    }
    internal class Dog : Pet, ITrainable
    {
        public Dog(string name, int age, string bread) : base(name, age, bread) { }
        public string Train()
        {
            return $"到处撒尿...";
        }
        override public string Speak()
        {
            return $"汪~汪~汪~";
        }
        override public string Eat()
        {
            return $"在吃屎";
        }
        public override string ToString()
        {
            return $"【{Bread}】{Name}{Speak()}的{Eat()},训练他{Train()}。";
        }
    }
    internal class Cat : Pet, ITrainable
    {
        public Cat(string name, int age, string bread) : base(name, age, bread) { }
        public string Train()
        {
            return $"打碎杯子...";
        }
        override public string Speak()
        {
            return $"喵~喵~喵~";
        }
        override public string Eat()
        {
            return $"在吃罐罐";
        }
        public override string ToString()
        {
            return $"【{Bread}】{Name}{Speak()}的{Eat()},训练他{Train()}。";
        }
    }
    internal class Bird : Pet
    {
        public Bird(string name, int age, string bread) : base(name, age, bread) { }
        override public string Speak()
        {
            return $"啾~啾~啾~";
        }
        override public string Eat()
        {
            return $"在吃小虫子";
        }
        public override string ToString()
        {
            return $"【{Bread}】{Name}{Speak()}的{Eat()}。";
        }
    }
    internal class PetManagementSystem
    {
        public List<Pet> list = new List<Pet>();
        public void Add()
        {
            Console.Write("请选择宠物类型：1狗2猫3鸟：");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    string name = Console.ReadLine();
                    string bread = Console.ReadLine();
                    int age = Convert.ToInt32(Console.ReadLine());
                    list.Add(new Dog(name, age, bread));
                    break;
                case 2:
                    name = Console.ReadLine();
                    bread = Console.ReadLine();
                    age = Convert.ToInt32(Console.ReadLine());
                    list.Add(new Cat(name, age, bread));
                    break;
                case 3:
                    name = Console.ReadLine();
                    bread = Console.ReadLine();
                    age = Convert.ToInt32(Console.ReadLine());
                    list.Add(new Bird(name, age, bread));
                    break;
                default:
                    break;
            }
        }
        public void DisplayPets()
        {
            list.ForEach(x => Console.WriteLine(x));
        }
        public void ClassPet()
        {
            Console.WriteLine("请选择宠物类型：1狗2猫3鸟：");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    list.FindAll(x => x is Dog).ForEach(x => Console.WriteLine(x));
                    break;
                case 2:
                    list.FindAll(x => x is Cat).ForEach(x => Console.WriteLine(x));

                    break;
                case 3:
                    list.FindAll(x => x is Bird).ForEach(x => Console.WriteLine(x));
                    break;
                default:
                    break;
            }
        }
        public void TrainPet()
        {
            foreach (var pet in list.OfType<ITrainable>())
            {
                Console.WriteLine(pet.Train());
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PetManagementSystem p = new PetManagementSystem();
            while (true)
            {
                Console.Write("请选择功能：1添加2列出3分组4训练5退出：");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        p.Add(); break;
                    case 2:
                        p.DisplayPets(); break;
                    case 3:
                        p.ClassPet(); break;
                    case 4:
                        p.TrainPet(); break;
                    case 5: return;
                    default:
                        break;
                }
            }
        }
    }
}
