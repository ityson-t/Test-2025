namespace Chapter8
{
    class MyClass
    {
        readonly int intValue;
        readonly double doubleValue;
        public string Name;
        public int UserId;
        private MyClass()
        {
            intValue = 10;
            doubleValue = 20.5;
        }
        public MyClass(string name) : this()
        {
            Name = name;
        }
        public MyClass(int id) : this()
        {
            UserId = id;
        }
        public override string ToString()
        {
            return $"姓名：{Name}, 用户ID：{UserId}, int值：{intValue}, double值：{doubleValue}"; 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyClass obj1 = new MyClass("Alice");
                Console.WriteLine($"{obj1.ToString()}");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
