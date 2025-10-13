using System.Security.Cryptography;

namespace StockMarketObserverSystem
{
    delegate void StockPriceChangedHandler(string stockName, double oldPrice, double newPrice);
    internal class Stock
    {
        public event StockPriceChangedHandler PriceChanged;
        public event StockPriceChangedHandler HighVolatility;
        public string StockName { get; private set; }
        public double Price { get; private set; }
        public Stock(string stockName, double price)
        {
            StockName = stockName;
            Price = price;
        }
        public void SetPrice(double newPrice)
        {
            double oldPrice = Price;
            Price = newPrice;
            PriceChanged?.Invoke(StockName, oldPrice, newPrice);
            if ((oldPrice - newPrice) / oldPrice > 0.1 || (oldPrice - newPrice) / oldPrice < -0.1)
            {
                HighVolatility?.Invoke(StockName, oldPrice, newPrice);
            }
        }
    }
    internal interface IListener
    {
        abstract public string Name { get; set; }
        abstract public void PriceChangedRecevied(string stockName, double oldPrice, double newPrice);
    }
    internal class Investor : IListener
    {
        public string Name { get; set; }
        public Investor(List<Stock> stocks, string name)
        {
            Name = name;
            foreach (var stock in stocks)
            {
                stock.PriceChanged += PriceChangedRecevied;
                stock.HighVolatility += HighVolatilityRecevied;
            }            
        }
        public void PriceChangedRecevied(string stockName, double oldPrice, double newPrice)
        {
            Console.WriteLine($"[投资者]：{Name}-收到股票{stockName}价格{oldPrice}-{newPrice}变动通知。");
        }
        public void HighVolatilityRecevied(string stockName, double oldPrice, double newPrice)
        {
            Console.WriteLine($"[投资者]：{Name}-收到股票{stockName}大幅度波动通知。");
        }
    }
    internal class Broker : IListener
    {
        public string Name { get; set; }
        public Broker(List<Stock> stocks, string name)
        {
            Name = name;
            foreach (var stock in stocks)
            {
                stock.PriceChanged += PriceChangedRecevied;
            }
        }
        public void PriceChangedRecevied(string stockName, double oldPrice, double newPrice)
        {
            Console.WriteLine($"[券商]：{Name}-收到股票{stockName}变动通知。");
        }
    }
    internal class StockMarket
    {
        public List<Stock> stocks = new List<Stock>();
        public List<IListener> listeners = new List<IListener>();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StockMarket stockMarket = new StockMarket();
            stockMarket.stocks.Add(new("01", 11.22));
            stockMarket.stocks.Add(new("02", 9.46));
            stockMarket.stocks.Add(new("03", 8.87));
            stockMarket.listeners.Add(new Investor(stockMarket.stocks, "张一元"));
            stockMarket.listeners.Add(new Broker(stockMarket.stocks, "李何一"));
            stockMarket.stocks[0].SetPrice(11.25);
            Console.WriteLine();
            stockMarket.stocks[1].SetPrice(11.25);
            Console.WriteLine();
            stockMarket.stocks[2].SetPrice(11.25);

            //Console.WriteLine(  );
            //stockMarket.stocks[2].SetPrice(35); Console.WriteLine( );
            //stockMarket.stocks[3].SetPrice(7.76);
        }
    }
}
