using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LibrarySystem
{

    internal class UserInputHelper
    {
        public static string GetStringInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Menu.InvalidOption();
                    continue;
                }
            }
        }
        public static int GetIntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Menu.InvalidOption();
                    continue;
                }
            }
        }
        public static int GetIntInput(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                {
                    return result;
                }
                else
                {
                    Menu.InvalidOption();
                    continue;
                }
            }
        }
        public static decimal GetDecimalInput(string prompt)
        {
            decimal result;
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Menu.InvalidOption();
                    continue;
                }
            }
        }
    }
    internal class Menu
    {
        public static void Show()
        {
            Console.WriteLine("欢迎使用图书管理系统");
            Console.WriteLine("1. 添加图书");
            Console.WriteLine("2. 借阅图书");
            Console.WriteLine("3. 归还图书");
            Console.WriteLine("4. 查看所有图书");
            Console.WriteLine("5. 退出系统");
        }
        public static void InvalidOption()
        {
            Console.Write("输入错误，");
        }
        public static void Exit()
        {
            Console.WriteLine("感谢使用图书管理系统，再见！");
        }
        public static void ShowAddBookList()
        {
            Console.WriteLine("1.添加纸质书");
            Console.WriteLine("2.添加电子书");
            Console.WriteLine("3.返回主菜单");
        }
        public static void ShowList()
        {
            Console.WriteLine($"1.继续操作");
            Console.WriteLine($"2.返回主菜单");
        }
    }
    internal class Library
    {
        public bool HasCopyWithStatus(List<Book> books, string isbn, bool status)
        {
            foreach (var item in books)
            {
                if (item.ISBN == isbn && item.IsAvailable == status)
                {
                    return true;
                }
            }
            return false;
        }
        public void Borrow(List<Book> books, string isbn, bool status)
        {
            bool isFound = false;
            foreach (var item in books)
            {
                if (item.ISBN == isbn && item.IsAvailable == status)
                {
                    item.Borrow(item);
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                throw new InvalidOperationException("该图书无可借副本，无法借阅。");

            }
        }
        public void Return(List<Book> books, string isbn,bool status)
        {
            bool isFound = false;
            foreach (var item in books)
            {
                if (item.ISBN == isbn&&item.IsReturnable==status)
                {
                    item.Return(item);
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                throw new InvalidOperationException("该图书未借出，无法归还。");
            }

        }

        public void Displayinventory(List<Book> books)
        {
            if (books.Count != 0)
            {
                foreach (var item in books)
                {
                    Console.WriteLine($"{item.ToString()}");
                }
            }
            else
            {
                Console.WriteLine("当前无库存图书。");
            }
        }

        public Book AddBook(int userChoice)
        {
            if (userChoice == 1)
            {
                string title = UserInputHelper.GetStringInput("请输入书名：");
                string isbn = UserInputHelper.GetStringInput("请输入ISBN：");
                string author = UserInputHelper.GetStringInput("请输入作者：");
                decimal price = UserInputHelper.GetDecimalInput("请输入价格：");
                return new PhysicalBook(title, isbn, author, price);
            }
            else
            {
                string title = UserInputHelper.GetStringInput("请输入书名：");
                string isbn = UserInputHelper.GetStringInput("请输入ISBN：");
                string author = UserInputHelper.GetStringInput("请输入作者：");
                decimal price = UserInputHelper.GetDecimalInput("请输入价格：");
                return new EBook(title, isbn, author, price);
            }
        }
    }
    abstract internal class Book
    {
        abstract public string Title { get; set; }
        abstract public string Author { get; set; }
        abstract public string ISBN { get; set; }
        abstract public decimal Price { get; set; }
        virtual public bool IsAvailable { get; set; } = true;
        virtual public bool IsReturnable { get; set; } = false;
        public Book(string title, string author, string isbn, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Price = price;
        }
        //abstract public Book AddBook();
        override public string ToString()
        {
            return $"书名: {Title}, 作者: {Author}, ISBN: {ISBN}, 价格: {Price}, 是否可借: {IsAvailable}";
        }
        abstract public void Borrow(Book book);
        abstract public void Return(Book book);
    }
    internal class PhysicalBook : Book
    {
        public override string Title
        {
            get; set;
        }
        public override string Author
        {
            get; set;
        }
        public override string ISBN { get; set; }
        public override decimal Price
        {
            get; set;
        }
        public int CopiesAvailable
        {
            get; set;
        }
        public int TotalCopies
        {
            get; set;
        }
        public PhysicalBook(string title, string author, string isbn, decimal price) : base(title, author, isbn, price)
        {
            CopiesAvailable = UserInputHelper.GetIntInput("请输入入库数量：");
            TotalCopies = CopiesAvailable;
        }
        //public override Book AddBook()
        //{
        //    string title = UserInputHelper.GetStringInput("请输入书名: ");
        //    string author = UserInputHelper.GetStringInput("请输入作者: ");
        //    string isbn = UserInputHelper.GetStringInput("请输入ISBN: ");
        //    decimal price = UserInputHelper.GetDecimalInput("请输入价格: ");
        //    int copiesAvailable = UserInputHelper.GetIntInput("请输入副本数: ");
        //    return new PhysicalBook(title, author, isbn, price);
        //}
        public override string ToString()
        {
            return $"书名: {Title}, 作者: {Author}, ISBN: {ISBN}, 价格: {Price}, 是否可借: {IsAvailable},是否可还：{IsReturnable} 剩余副本数: {CopiesAvailable}";
        }
        public override void Borrow(Book book)
        {
            if (CopiesAvailable > 0)
            {
                CopiesAvailable--;
                IsReturnable = true;
                if (CopiesAvailable == 0)
                {
                    IsAvailable = false;
                }
                Console.WriteLine("借阅成功！");
            }
            else
            {
                throw new InvalidOperationException("该图书无可借副本，无法借阅。");
            }
        }
        public override void Return(Book book)
        {
            if (TotalCopies > CopiesAvailable)
            {
                CopiesAvailable++;
                IsAvailable = true;
                if (CopiesAvailable == TotalCopies)
                {
                    IsReturnable=false;
                }
                Console.WriteLine("归还成功！");
            }
            else
            {
                throw new InvalidOperationException("该图书未借出，无法归还。");
            }
        }
    }
    internal class EBook : Book
    {
        string downloadLink;
        public override string Title
        {
            get;
            set;
        }
        public override string Author
        {
            get; set;
        }
        public override string ISBN { get; set; }
        public override decimal Price
        {
            get; set;
        }
        public string DownloadLink
        {
            get; set;
        }
        public EBook(string title, string author, string isbn, decimal price) : base(title, author, isbn, price)
        {
            DownloadLink = UserInputHelper.GetStringInput("请输入下载链接：");
        }
        public override string ToString()
        {
            return $"书名: {Title}, 作者: {Author}, ISBN: {ISBN}, 价格: {Price}, 是否可借: {IsAvailable}";
        }
        public override void Borrow(Book book)
        {
            Console.WriteLine($"电子书下载链接：{this.DownloadLink}");
        }
        public override void Return(Book book)
        {
            Console.WriteLine("电子书无需归还。");
        }
    }

    internal class Program
    {
        static void Main()
        {
            List<Book> books = new List<Book>();
            Library library = new Library();
            while (true)
            {
                Menu.Show();
                int userSelect = UserInputHelper.GetIntInput("请选择操作（1-5）：", 1, 5);
                switch (userSelect)
                {
                    case 1:
                        while (true)
                        {
                            Menu.ShowAddBookList();
                            int nextAction = UserInputHelper.GetIntInput("请选择操作（1-3）：", 1, 3);
                            if (nextAction == 1)
                            {
                                books.Add(library.AddBook(nextAction));
                                continue;
                            }
                            else if (nextAction == 2)
                            {
                                books.Add(library.AddBook(nextAction));
                            }
                            else
                            {
                                break;
                            }
                        }

                        break;
                    case 2:
                        while (true)
                        {
                            Menu.ShowList();
                            if (UserInputHelper.GetIntInput("请选择操作（1-2）：", 1, 2) == 1)
                            {
                                try
                                {
                                    library.Borrow(books, UserInputHelper.GetStringInput("请输入ISBN："), true);
                                    continue;
                                }
                                catch (InvalidOperationException ex)
                                {

                                    Console.WriteLine($"{ex.Message}");
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            Menu.ShowList();
                            if (UserInputHelper.GetIntInput("请选择操作（1-2）：", 1, 2) == 1)
                            {
                                try
                                {
                                    library.Return(books, UserInputHelper.GetStringInput("请输入ISBN："), true);
                                    continue;
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine($"{ex.Message}");
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case 4:
                        library.Displayinventory(books);
                        break;
                    case 5:
                        Menu.Exit();
                        return;
                    default:
                        break;
                }
            }

        }
    }
}

