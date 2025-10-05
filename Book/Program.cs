namespace Book
{
    internal class UserInputHelper
    {
        public static int CheckQuantity(string prompt)
        { 
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int quantity))
                {
                    return quantity;
                }
                else
                {
                    Console.Write("输入错误，");
                    continue;
                }
            }
        }
        public static decimal CheckPrice(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                if (decimal.TryParse(userInput, out decimal price) && price >= 0)
                {
                    return price;
                }
                else
                {
                    Console.Write("输入错误，");
                    continue;
                }
            }
        }

    }
    internal class Book
    {
        string title;
        string author;
        string isbn;
        decimal price;
        int availableCopies;
        public Book(string title, string author, string isbn, decimal price, int availableCopies)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.price = price;
            this.availableCopies = availableCopies;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"书名: {title}");
            Console.WriteLine($"作者: {author}");
            Console.WriteLine($"ISBN: {isbn}");
            Console.WriteLine($"价格: {price:C}");
            Console.WriteLine($"库存: {availableCopies}");
        }
        public void SellBook(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("销售数量必须大于0");
            }
            if (quantity > availableCopies)
            {
                throw new ArgumentException("库存不足");
            }
            availableCopies -= quantity;
            Console.WriteLine($"成功售出 {quantity} 本《{title}》。剩余库存: {availableCopies}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("C#编程指南", "张三", "978-7-123-45678-9", 99m, 50);
            book.DisplayInfo();
            while (true)
            {
                int quantityToSell = UserInputHelper.CheckQuantity("请输入要销售的数量: ");
                try
                {
                    book.SellBook(quantityToSell);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"错误: {ex.Message}");
                }
            }
            
        }
    }
}
