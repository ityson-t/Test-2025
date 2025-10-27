namespace Test2025102004
{
    enum Direction { Book, Food, Toy }
    struct Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Direction Direction { get; set; }
        public Product(string name, decimal price, Direction direction)
        {
            Name = name;
            Price = price;
            Direction = direction;
        }
        public override string ToString()
        {
            return $"商品种类：{Direction}--商品名称：{Name}--商品价格：{Price}。";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("1 book", 15, Direction.Book));
            products.Add(new Product("2 book", 90, Direction.Book));
            products.Add(new Product("3 book", 126, Direction.Book));
            products.Add(new Product("1 food", 4, Direction.Food));
            products.Add(new Product("2 food", 7, Direction.Food));
            products.Add(new Product("3 food", 19, Direction.Food));
            products.Add(new Product("4 Book", 67, Direction.Book));
            products.Add(new Product("2 toy", 333, Direction.Toy));
            products.Add(new Product("4 food", 26, Direction.Food));
            products.Add(new Product("1 toy", 78, Direction.Toy));
            products.Add(new Product("3 toy", 127, Direction.Toy));
            products.ForEach(product => Console.WriteLine(product));
            Console.WriteLine();
            products.FindAll(x =>x.Direction==Direction.Toy).ForEach(product => Console.WriteLine(product));
            Console.WriteLine();
            Console.WriteLine($"{products.Average(x => x.Price):f2}");
            Console.WriteLine();
            Console.WriteLine($"{products.Max(x=>x.Price):f2}");
        }
    }
}
