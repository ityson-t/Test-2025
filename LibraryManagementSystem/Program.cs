using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.InteropServices;

namespace LibraryManagementSystem
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
        public static void ShowList()
        {
            Console.WriteLine("1.继续操作");
            Console.WriteLine("2.返回主菜单");
        }
    }
    internal class Library
    {        
        public bool CheckInStock(List<Book> bookList, string isbn)
        {
            foreach (var item in bookList)
            {
                if (item.ISBN == isbn)
                {
                    return true;
                }
            }
            return false;            
        }
        public void Borrow(List<Book> bookList, string isbn)
        {
            if (this.CheckInStock(bookList, isbn))
            {
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookList[i].ISBN != isbn)
                    {
                        continue;
                    }
                    else if (bookList[i].IsAvailable == true)
                    {
                        bookList[i].IsAvailable = false;
                        Console.WriteLine($"借阅成功！");
                        break;
                    }
                    else
                    {
                        throw new InvalidOperationException("该图书已被借出，无法借阅。");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("该图书无库存记录，无法借阅。");
            }
        }
        public void Return(List<Book> bookList, string isbn)
        {
            if (this.CheckInStock(bookList, isbn))
            {
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookList[i].ISBN != isbn)
                    {
                        continue;
                    }
                    else if (bookList[i].IsAvailable == false)
                    {
                        bookList[i].IsAvailable = true;
                        Console.WriteLine($"归还成功！");
                        break;
                    }
                    else
                    {
                        throw new InvalidOperationException("该图书未借出，无法归还。");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("该图书无库存记录，，无法归还。");
            }
        }
        public void Displayinventory(List<Book> bookList)
        {
            if (bookList.Count != 0)
            {
                foreach (var item in bookList)
                {
                    Console.WriteLine($"{item.ToString()}");
                }                
            }
            else
            {
                Console.WriteLine("当前无库存图书。");
            }
        }
        public Book AddBook()
        {
            string title = UserInputHelper.GetStringInput("请输入书名：");
            string isbn = UserInputHelper.GetStringInput("请输入ISBN：");
            string author = UserInputHelper.GetStringInput("请输入作者：");
            decimal price = UserInputHelper.GetDecimalInput("请输入价格：");
            Book newBook = new Book(title, isbn, author, price);
            return newBook;
        }
    }
    internal class Book
    {
        string _title;
        string _isbn;
        string _author;
        decimal _price;
        bool _isAvailable = true;
        public string ISBN { get { return _isbn; } }
        public string Title
        {
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("书名不能为空。");
                }
                else
                {
                    _title = value;
                }
            }
            get { return _title; }
        }
        public string Author
        {
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("作者不能为空。");
                }
                else
                {
                    _author = value;
                }
            }
            get { return _author; }
        }
        public decimal Price
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("价格不能为0或负数。");
                }
                else
                {
                    _price = value;
                }
            }
            get { return _price; }
        }
        public bool IsAvailable
        {
            set { _isAvailable = value; }
            get { return _isAvailable; }
        }
        public Book(string title, string isbn, string author, decimal price)
        {
            Title = title;
            _isbn = isbn;
            Author = author;
            Price = price;
        }        
        public override string ToString()
        {
            return $"书名: {_title}, ISBN: {_isbn}, 作者: {_author},价格：￥{Price:f2} 是否可借: {(_isAvailable ? "是" : "否")}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            List<Book> bookList= new List<Book>(); 
            while (true)
            {
                Menu.Show();
                int userSelect = UserInputHelper.GetIntInput("请选择操作（1-5）：", 1, 5);
                switch (userSelect)
                {
                    case 1:
                        while (true)
                        {
                            Menu.ShowList();
                            int nextAction = UserInputHelper.GetIntInput("请选择操作（1-2）：", 1, 2);
                            if (nextAction == 1)
                            {
                                bookList.Add(library.AddBook());
                                continue;
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
                                    library.Borrow(bookList, UserInputHelper.GetStringInput("请输入ISBN："));
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
                                    library.Return(bookList, UserInputHelper.GetStringInput("请输入ISBN："));
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
                        library.Displayinventory(bookList);
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
