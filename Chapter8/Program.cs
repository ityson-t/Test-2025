using System.Security;

namespace Chapter8
{
    internal class Book
    {
        public string Name { get; set; }
        public string Aother { get; set; }
        public decimal Price { get; set; }
        public Book(string name, string aother, decimal price)
        {
            this.Name = name;
            this.Aother = aother;
            this.Price = price;
        }
        public override string ToString()
        {
            return $"书名：{Name} 作者：{Aother} 价格：{Price}";
        }
    }
    class Program
    {
        static void Main()
        {
            List<Book> books = [];
            books.Add(new("第一本书", "英国人", 188));
            books.Add(new("第二本书", "Alice", 109));
            books.Add(new("第三本书", "中国人", 30));
            books.Add(new("第四本书", "Alice", 20));
            Console.WriteLine();
            Console.WriteLine($"书库列表：");
            foreach (var item in books)
            {
                Console.WriteLine($"{item}");
            }
            List<Book> newBooks = [];
            foreach (Book book in books)
            {
                if (book.Price > 50)
                {
                    newBooks.Add(book);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"价格高于50的书列表：");
            foreach (var item in newBooks)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
            Console.WriteLine($"价格高于50的书列表，用命名方法实现：");
            static bool IsExpensive(Book b)
            {
                return b.Price > 50;
            }
            List<Book> exBooks = books.FindAll(IsExpensive);
            foreach (Book book in exBooks)
            {
                Console.WriteLine($"{book}");
            }
            Console.WriteLine();
            Console.WriteLine($"价格高于50的书列表，用匿名方法实现：");
            List<Book> exBooks1 = books.FindAll(delegate (Book b) { return b.Price > 50; });
            foreach (var item in exBooks1)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
            Console.WriteLine($"价格高于50的书列表，用Lambda表达式实现：");
            List<Book> exBooks2 = books.FindAll(b => b.Price > 50);
            foreach (var item in exBooks2)
                Console.WriteLine($"{item}");
            Console.WriteLine();
            Console.WriteLine($"价格高于50的书列表，用LINQ完整语句实现：");
            var exBook3 = from book in books
                          where book.Price > 50
                          select book;
            foreach (var item in exBook3)
                Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine($"用List<T>.ForEach(Action<T>)匿名方法输出图书列表：");
            books.ForEach(delegate (Book book) { Console.WriteLine(book); ; });
            Console.WriteLine();
            Console.WriteLine($"用Lambda表达式输出图书列表：");
            books.ForEach(b => Console.WriteLine(b));
            Console.WriteLine();
            Console.WriteLine($"用LINQ完整查询输出图书列表：");
            var exBook4 = from book in books
                          select book;
            foreach (var item in exBook4)
                Console.WriteLine(item);
            Console.WriteLine();
            List<string> strings = [];
            foreach (var item in books)
            {
                strings.Add(item.Name);
            }
            Console.WriteLine($"只保留书名的列表：");
            foreach (var item in strings)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("用LinQ只保留书名：");
            var exBook5 = from Book in books
                          select Book.Name;
            foreach (var item in exBook5)
                Console.Write($"{item} ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("用LINQ查询某作者的书：");
            var exBooks6 = from Book in books
                           where Book.Aother == "Alice"
                           select Book;
            foreach (var item in exBooks6)
                Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("用Lambda表达式查询某作者的书：");
            var exBooks12 = books.FindAll(b => b.Aother == "Alice");
            foreach (var item in exBooks12)
                Console.WriteLine(item);
            Console.WriteLine();
            foreach (var item in books)
            {
                if (item.Aother == "Alice")
                {
                    Console.WriteLine($"{item}");
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("用LINQ查询价格大于50且作者不是'Alice'的书：");
            var exBook7 = from Book in books
                          where Book.Price > 50
                          where Book.Aother != "Alice"
                          select Book;
            foreach (var item in exBook7)
                Console.WriteLine($"{item} ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("按价格从低到高排序的书：");
            var exBooks8 = from Book in books
                           orderby Book.Price
                           select Book;
            foreach (var item in exBooks8)
                Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("按作者分组后的书籍：");
            var exBooks9 = from Book in books
                           group Book by Book.Aother;
            foreach (var item in exBooks9)
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item)
                    Console.WriteLine(item2);
            }
            Console.WriteLine();
            Console.WriteLine("仅输出书名与价格（投影操作）：");
            var exBook10 = from Book in books
                           select new { Book.Name, Book.Price };
            foreach (var item in exBook10)
                Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("每位作者的平均价格：");
            var avgPrice = from Book in books
                           group Book by Book.Aother
                            into newExBooks
                           select new
                           {
                               Aother = newExBooks.Key,
                               AveragePrice = newExBooks.Average(x => x.Price)
                           };
            foreach (var item in avgPrice)
                Console.WriteLine($"{item.Aother}的平均价格：{item.AveragePrice}");
            Console.WriteLine();
            Console.WriteLine("最高价的书：");
            var maxPrice = books.OrderByDescending(x => x.Price).First();
            Console.WriteLine(maxPrice);
            Console.WriteLine();
            Console.WriteLine("最低价的书：");
            var minPrice = books.OrderBy(x => x.Price).First();
            Console.WriteLine(minPrice);
            Console.WriteLine();
            Console.WriteLine($"是否所有书都大于10元：");
            bool allAbove10 = books.All(x => x.Price > 10);
            Console.WriteLine($"{(allAbove10?"是":"不是")}");
            Console.WriteLine();
            Console.WriteLine("是否存在低于30元的书：");
            bool hasCheap = books.Any(x => x.Price > 30);
            Console.WriteLine($"{(hasCheap?"是":"不是")}");
            Console.WriteLine();
            Console.WriteLine("书籍总数与总价格：");
            var sumPrice=books.Sum(x=>x.Price);
            Console.WriteLine($"一共有{books.Count}本书，总价{sumPrice}");
            Console.WriteLine();
            Console.WriteLine("作者 Alice 的最贵书：");
            var aliceExBook=books.FindAll(b=>b.Aother=="Alice").OrderByDescending(x=>x.Price).FirstOrDefault();
            Console.WriteLine(aliceExBook != null ? aliceExBook.ToString() : "未找到");
        }
    }
}




