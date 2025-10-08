namespace Chapter8
{
    using System;
    using System.Collections.Generic;

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
                Console.WriteLine("输入错误，请重新输入。");
            }

            public static void Exit()
            {
                Console.WriteLine("感谢使用图书管理系统，再见！");
            }

            public static void ShowAddBookList()
            {
                Console.WriteLine("1. 添加纸质书");
                Console.WriteLine("2. 添加电子书");
                Console.WriteLine("3. 返回主菜单");
            }

            public static void ShowList()
            {
                Console.WriteLine("1. 继续操作");
                Console.WriteLine("2. 返回主菜单");
            }
        }

        internal class Library
        {
            public void Borrow(List<Book> books, string isbn)
            {
                bool isFound = false;
                foreach (var item in books)
                {
                    if (item.ISBN == isbn && item.IsAvailable)
                    {
                        item.Borrow();
                        isFound = true;
                        break;
                    }
                }
                if (!isFound)
                {
                    throw new InvalidOperationException("该图书无可借副本，无法借阅。");
                }
            }

            public void Return(List<Book> books, string isbn)
            {
                bool isFound = false;
                foreach (var item in books)
                {
                    if (item.ISBN == isbn && item.IsReturnable)
                    {
                        item.Return();
                        isFound = true;
                        break;
                    }
                }
                if (!isFound)
                {
                    throw new InvalidOperationException("该图书未借出，无法归还。");
                }
            }

            public void DisplayInventory(List<Book> books)
            {
                if (books.Count != 0)
                {
                    foreach (var item in books)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("当前无库存图书。");
                }
            }

            public Book AddBook(int userChoice)
            {
                string title = UserInputHelper.GetStringInput("请输入书名：");
                string isbn = UserInputHelper.GetStringInput("请输入ISBN：");
                string author = UserInputHelper.GetStringInput("请输入作者：");
                decimal price = UserInputHelper.GetDecimalInput("请输入价格：");

                if (userChoice == 1)
                {
                    return new PhysicalBook(title, isbn, author, price);
                }
                else
                {
                    return new EBook(title, isbn, author, price);
                }
            }
        }

        abstract internal class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string ISBN { get; }
            public decimal Price { get; set; }
            public virtual bool IsAvailable => true;
            public virtual bool IsReturnable => false;

            protected Book(string title, string author, string isbn, decimal price)
            {
                Title = title;
                Author = author;
                ISBN = isbn;
                Price = price;
            }

            public override string ToString()
            {
                return $"书名: {Title}, 作者: {Author}, ISBN: {ISBN}, 价格: {Price}, 是否可借: {IsAvailable}";
            }

            public abstract void Borrow();
            public abstract void Return();
        }

        internal class PhysicalBook : Book
        {
            public int CopiesAvailable { get; private set; }
            public int TotalCopies { get; }

            public PhysicalBook(string title, string author, string isbn, decimal price) : base(title, author, isbn, price)
            {
                CopiesAvailable = UserInputHelper.GetIntInput("请输入入库数量：");
                TotalCopies = CopiesAvailable;
            }

            public override bool IsAvailable => CopiesAvailable > 0;
            public override bool IsReturnable => TotalCopies > CopiesAvailable;

            public override string ToString()
            {
                return base.ToString() + $", 是否可还: {IsReturnable}, 剩余副本数: {CopiesAvailable}";
            }

            public override void Borrow()
            {
                if (CopiesAvailable > 0)
                {
                    CopiesAvailable--;
                    Console.WriteLine("借阅成功！");
                }
                else
                {
                    throw new InvalidOperationException("该图书无可借副本，无法借阅。");
                }
            }

            public override void Return()
            {
                if (TotalCopies > CopiesAvailable)
                {
                    CopiesAvailable++;
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
            public string DownloadLink { get; set; }

            public EBook(string title, string author, string isbn, decimal price) : base(title, author, isbn, price)
            {
                DownloadLink = UserInputHelper.GetStringInput("请输入下载链接：");
            }

            public override bool IsAvailable => true;
            public override bool IsReturnable => false;

            public override string ToString()
            {
                return base.ToString() + $", 下载链接: {DownloadLink}";
            }

            public override void Borrow()
            {
                Console.WriteLine($"电子书下载链接：{DownloadLink}");
            }

            public override void Return()
            {
                throw new InvalidOperationException("电子书无需归还。");
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
                                if (nextAction == 1 || nextAction == 2)
                                {
                                    books.Add(library.AddBook(nextAction));
                                    Console.WriteLine("图书添加成功！");
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
                                        library.Borrow(books, UserInputHelper.GetStringInput("请输入ISBN："));
                                        Console.WriteLine("操作完成！");
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
                                        library.Return(books, UserInputHelper.GetStringInput("请输入ISBN："));
                                        Console.WriteLine("操作完成！");
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
                            library.DisplayInventory(books);
                            Console.WriteLine("\n按回车返回主菜单...");
                            Console.ReadLine();
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
}
