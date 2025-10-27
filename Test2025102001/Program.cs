using System.Threading.Channels;

namespace Test2025102001
{
    delegate void NotifyEventHandler(string temp);
    internal class TemperatureSensor
    {
        public event NotifyEventHandler TemperatureChanged;
        public double Temperature { get; set; }
        public void ChangeTemperature(string temp)
        {
            if (double.TryParse(temp, out double tempValue))
            {
                Temperature = tempValue;
                if (TemperatureChanged != null)
                    TemperatureChanged(temp);
            }
            else
            {
                throw new ArgumentException("输入错误：");
            }
        }
    }
    internal class Alarm
    {
        public Alarm(TemperatureSensor temperature)
        {
            temperature.TemperatureChanged += TemperatureAlarm;
        }
        public void TemperatureAlarm(string temp)
        {
            if (double.TryParse(temp, out double tempValue) && tempValue > 38)
            {
                Console.WriteLine($"高温预警...现在温度是{tempValue}度...");
            }
        }
    }
    internal class Logger
    {
        List<string> log = new List<string>();
        public Logger(TemperatureSensor temperatureSensor)
        {
            temperatureSensor.TemperatureChanged += Add;
        }
        public void Add(string temp)
        {
            log.Add(temp);
        }
        public void DisplayLog()
        {
            log.ForEach(x => Console.WriteLine(x));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TemperatureSensor temperatureSensor = new TemperatureSensor();
            Alarm alarm = new Alarm(temperatureSensor);
            Logger logger = new Logger(temperatureSensor);
            while (true)
            {
                Console.Write($"选择操作，1变温2显示3取消预警4取消日志5退出：");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        try
                        {
                            Console.Write($"请输入温度：");
                            string temp = Console.ReadLine();
                            temperatureSensor.ChangeTemperature(temp);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        logger.DisplayLog(); break;
                    case 3: temperatureSensor.TemperatureChanged -= alarm.TemperatureAlarm; break;
                    case 4: temperatureSensor.TemperatureChanged -= logger.Add; break;
                    case 5: return;
                    default:
                        break;
                }
            }
        }
    }
}
