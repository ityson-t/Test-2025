using System.Runtime.CompilerServices;

namespace Test2025102003
{
    internal class GameEventArg : EventArgs
    {
        public int Hp { get; set; }
        public GameEventArg(int hp) => this.Hp = hp;
    }
    internal class Gamer
    {
        public event EventHandler<GameEventArg> GamerHpChanged;
        public event EventHandler<GameEventArg> GamerDeath;
        public void OnGamerHpChanged()
        {
            if (GamerHP > 0)
            {
                GamerHpChanged?.Invoke(this, new GameEventArg(GamerHP));
            }
            else
                GamerDeath?.Invoke(this, new GameEventArg(GamerHP));
        }
        public int GamerHP { get; set; } = 100;
        public void Fight()
        {
            Console.WriteLine("被砍一刀...");
            GamerHP -= 10;
            OnGamerHpChanged();
        }
        public void Eat()
        {
            Console.WriteLine("吃个鸡腿...");
            GamerHP += 5;
            OnGamerHpChanged();
        }
    }
    internal class UI
    {
        public UI(Gamer gamer)
        {
            gamer.GamerHpChanged += Hert;
            gamer.GamerDeath += Death;
        }
        public void Hert(object s, GameEventArg eventArg)
        {
            Console.WriteLine($"...屏幕闪烁...");
        }
        public void Death(object s, GameEventArg eventArg)
        {
            Console.WriteLine($"...屏幕黑白...");
            Console.WriteLine($"...Game Over...");
        }
    }
    internal class SoundManager
    {
        public SoundManager(Gamer gamer)
        {
            gamer.GamerHpChanged += UiHert;
            gamer.GamerDeath += UiDeath;
        }
        public void UiHert(object s, GameEventArg eventArg)
        {
            Console.WriteLine($"叮~");
        }
        public void UiDeath(object s, GameEventArg eventArg) { Console.WriteLine($"额~~~"); }
    }
    internal class Logger
    {
        public List<string> log = new List<string>();
        public Logger(Gamer gamer)
        {
            gamer.GamerHpChanged += Log;
            gamer.GamerDeath += Log;
        }
        public void Log(object s, GameEventArg gameEventArg)
        {
            log.Add($"{DateTime.Now}---{gameEventArg.Hp.ToString()}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Gamer gamer = new Gamer();
            UI uI = new UI(gamer);
            SoundManager soundManager = new SoundManager(gamer);
            Logger logger = new Logger(gamer);
            while (true)
            {
                Console.Write($"1打2加3志4退：");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        gamer.Fight(); break;
                    case 2:
                        gamer.Eat(); break;
                    case 3:
                        logger.log.ForEach(x => Console.WriteLine(x));break;
                    case 4:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
