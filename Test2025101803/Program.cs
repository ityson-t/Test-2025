namespace Test2025101803
{
    //    Day 4：类与对象（面向对象回顾）
    //目标：练习定义类、构造函数、属性、ToString()。
    //任务内容
    //定义一个 Book 类：
    //属性：Name、Author、Price；
    //重写 ToString()；
    //创建 List<Book>；
    //输出：
    //所有书；
    //价格超过 50 的书；
    //最贵的一本书（使用循环）。

    //    Day 6：LINQ 初步
    //目标：掌握 LINQ 查询语法的基础结构。
    //任务内容
    //用 from...where...select...查询价格大于 50 的书；
    //查询作者为某人的书；
    //查询并投影成匿名类型：new { Name, Price}；
    //使用 orderby 实现排序。

    //🗓 Day 7：LINQ 进阶练习
    //目标：掌握分组与聚合操作。
    //任务内容
    //按作者分组输出；
    //计算每位作者的平均价格；
    //查找最高价、最低价；
    //练习 All()、Any()、Sum()、Average()。
    internal class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public Book(string name, string author, double price)
        {
            Name = name;
            Author = author;
            Price = price;
        }
        public override string ToString()
        {
            return $"书名：{Name}，作者{Author}，价格{Price}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("第一本书", "美国人", 39));
            books.Add(new Book("第2 本书", "英国人", 319));
            books.Add(new Book("第3本书", "加国人", 139));
            books.Add(new Book("第4本书", "法国人", 391));
            books.Add(new Book("第5本书", "德国人", 391));
            books.Add(new Book("第6本书", "法国人", 391));
            books.Add(new Book("第7本书", "美国人", 391));
            books.Add(new Book("第8本书", "英国人", 391));
            books.ForEach(book => Console.WriteLine(book));
            books.FindAll(x => x.Price > 50).ForEach(book => Console.WriteLine(book));
            Book exBook = books.First();
            foreach (var item in books)
            {
                if (exBook.Price < item.Price)
                {
                    exBook = item;
                }
            }
            Console.WriteLine(exBook);
            //用 from...where...select...查询价格大于 50 的书；
            Console.WriteLine("用 from...where...select...查询价格大于 50 的书；");
            var priceAbove50 = from book in books
                               where book.Price > 50
                               select book;
            foreach (var item in priceAbove50)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("查询作者为某人的书；");
            var aotherBy = from book in books
                           where book.Author == "加国人"
                           select book;
            foreach (var item in aotherBy)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("查询并投影成匿名类型：new { Name, Price}；");
            var selectNew = from book in books
                            orderby book.Price
                            select new { book.Name, book.Author, book.Price };
            foreach (var item in selectNew)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("按作者分组输出；");
            var groupByAuther = from book in books
                                group book by book.Author;
            foreach (var item in groupByAuther)
            {
                Console.WriteLine(item.Key);
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1);
                }
            }
            Console.WriteLine("计算每位作者的平均价格；");
            var avgPrice = from book in books
                           group book by book.Author
                         into avgBooks
                           select new
                           {
                               Author = avgBooks.Key,
                               avg = avgBooks.Average(x => x.Price)
                           };
            foreach (var item in avgPrice)
            {
                Console.WriteLine($"{item.Author}的平均价格：{item.avg}");
            }
            Console.WriteLine("查找最高价、最低价；");
            var maxPrice = (from book in books
                            select book.Price).Max();
            var minPrice = (from book in books
                            select book.Price).Min();
            Console.WriteLine($"最高价{maxPrice},最低价{minPrice}");
            Console.WriteLine("练习 All()、Any()、Sum()、Average()");
            var sumPrice = (from book in books
                            select book.Price).Sum();
            var aPrice = (from book in books
                          select book.Price).Average();
            Console.WriteLine($"总价：{sumPrice},平均价：{aPrice}");
            var anyPrice = (from book in books
                            select book.Price).Any(x => x < 50);
            var allPrice = (from book in books
                            select book.Price).All(x => x > 50);
            Console.WriteLine($"有价格低于50元的书吗？{(anyPrice ? "有" : "没有")}");
            Console.WriteLine($"所有书都高于50元吗？{(allPrice ? "是" : "不是")}");
        }
    }
}
