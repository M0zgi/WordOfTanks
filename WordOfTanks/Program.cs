using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordOfTanks
{
    enum Color
    {
        Black,
        DarkBlue,
        DarkGreen,
        DarkCyan,
        DarkRed,
        DarkMagenta,
        DarkYellow,
        Gray,
        DarkGray,
        Blue,
        Green,
        Cyan,
        Red,
        Magenta,
        Yellow,
        White
    }

    class Player
    {        
        public string _Name { get; set; }
        public int _score { get; set; }

        public Player(string name, int score)
        {
            _Name = name;
            _score = score;
        }

        public string name;
    }
    abstract class Tank
    {
        public string Name { get; set; }
        public int Ammunition { get; set; }
        public int HP { get; set; }
        public int Maneuverability { get; set; }

        public int coordinationX { get; set; }
        public int coordinationY { get; set; }

        public Tank(int amunition, int hp, int maneuverability)
        {
            Ammunition = amunition;
            HP = hp;
            Maneuverability = maneuverability;
        }

        public Color color { get; set; }

        public abstract void Print();

        public abstract void playerScore();

        public static Tank operator* (Tank t1, Tank t2)
        {
            return t1 ^ t2;
        }

        public static Tank operator ^(Tank t1, Tank t2)
        {
            int hpT1 = (t1.HP - t2.Ammunition) * t1.Maneuverability;
            int hpT2 = (t2.HP - t1.Ammunition) * t2.Maneuverability;
            
            return hpT1 > hpT2 ? t1 : t2;
        }

        public override string ToString()
        {
            return $"Танк: {Name} " +
            $"Боекомплект танка: {Ammunition} " +
                $"Уровень брони: {HP} " +
                $"Маневренность: {Maneuverability}";                     
        }

        public static void ResetConsole()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;           
        }

        public void SetColor(Color color)
        {            
            string SetColor = Console.ReadLine();
            this.color = Enum.GetNames(typeof(Color)).Contains(SetColor) ? (Color)Enum.Parse(typeof(Color), SetColor) : color = Color.White;
        }
    }

    class T34: Tank
    {
        Player player;
        public T34(Player player, int amunition, int hp, int maneuverability) : base(amunition, hp, maneuverability)
        {
            Name = "T34";
            this.player = player;
            this.color = Color.Cyan;
        }

        public override void playerScore()
        {
            this.player._score++;
        }
        public override void Print()
        {
            Tank.ResetConsole();

            if (this.player.name == "p1")
            {
                if (coordinationY == 0)
                {
                    this.coordinationX = 0;
                    this.coordinationY = 0;
                }
            }

            else
            {
                if (coordinationX == 0)
                {
                    this.coordinationX = 45;
                    this.coordinationY = 0;
                }
            }
            Console.SetCursorPosition(this.coordinationX, this.coordinationY);

            Console.WriteLine($"Игрок {player._Name}, Количество очков: {player._score}");
            
            Console.ForegroundColor = (ConsoleColor)color;
            Console.SetCursorPosition(this.coordinationX, this.coordinationY += 1);

            Console.WriteLine($"Танк: {Name}");
            Console.SetCursorPosition(this.coordinationX, this.coordinationY += 1);

            Console.WriteLine($"Боекомплект танка: {Ammunition}");
            Console.SetCursorPosition(this.coordinationX, this.coordinationY += 1);

            Console.WriteLine($"Уровень брони: {HP}");
            Console.SetCursorPosition(this.coordinationX, this.coordinationY +=  1);

            Console.WriteLine($"Маневренность: {Maneuverability}");
            Tank.ResetConsole();            
        }       

        public override string ToString()
        {           
            return $"Игрок {player._Name} " + base.ToString();
        }  
    }

    class Pantera : Tank
    {
        Player player;
        public Pantera(Player player, int amunition, int hp, int maneuverability) : base(amunition, hp, maneuverability)
        {
            Name = "Pantera";
            this.player = player;
            this.color = Color.DarkGreen;
        }

        public override void playerScore()
        {
            this.player._score++;
        }
        public override void Print()
        {
            Tank.ResetConsole();
            if (this.player.name == "p1")
            {
                if (coordinationY == 0)
                {
                    this.coordinationX = 0;
                    this.coordinationY = 0;
                }                
            }

            else
            {
                if (coordinationX == 0)
                {
                    this.coordinationX = 45;
                    this.coordinationY = 0;
                }
            }
            Console.SetCursorPosition(this.coordinationX, this.coordinationY);

            Console.WriteLine($"Игрок {player._Name}, Количество очков: {player._score}");

            Console.ForegroundColor = (ConsoleColor)color;
            Console.SetCursorPosition(this.coordinationX, this.coordinationY += 1);

            Console.WriteLine($"Танк: {Name}");
            Console.SetCursorPosition(this.coordinationX, this.coordinationY += 1);

            Console.WriteLine($"Боекомплект танка: {Ammunition}");
            Console.SetCursorPosition(this.coordinationX, this.coordinationY += 1);

            Console.WriteLine($"Уровень брони: {HP}");
            Console.SetCursorPosition(this.coordinationX, this.coordinationY += 1);

            Console.WriteLine($"Маневренность: {Maneuverability}");
            Tank.ResetConsole();
            
        }
        public override string ToString()
        {            
            return $"Игрок {player._Name} " + base.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "WordOfTanks";
           
            Random rnd = new Random();

            Player p1 = new Player("Марго", 0);
            p1.name = nameof(p1);
            Player p2 = new Player("Александр", 0);
            p2.name = nameof(p2);

            Tank[] tanks1 = new Tank[12];

            //коэффициент шанса выпадания Т34
            double trueProbability = 0.2;
            bool result;

            for (int i = 0; i < tanks1.Length; i+=2)
            {
                result = rnd.NextDouble() < trueProbability;               

                if (result)
                {
                    tanks1[i] = new T34(p1, rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));
                }

                else
                {
                    tanks1[i] = new Pantera(p1, rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));
                }

                result = rnd.NextDouble() < trueProbability;

                if (result)
                {
                    tanks1[i + 1] = new T34(p2, rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));
                }

                else
                {
                    tanks1[i + 1] = new Pantera(p2, rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));
                } 
            }

            for (int i = 0; i < tanks1.Length; i++)
            {
                if (i % 2 == 0)
                {                    
                    Console.SetCursorPosition(0, tanks1[i].coordinationY + 6);
                    Console.Write("Результат битвы: ");
                    Tank buttle = tanks1[i] * tanks1[i + 1];

                    //увеличиваем количество побед у победителя
                    buttle.playerScore();

                    Console.Write($"победитель {buttle}");
                }

                tanks1[i].Print();                

                if (i < tanks1.Length - 2)
                {
                    if (i % 10 == 0)
                    {  
                        tanks1[i + 2].coordinationX = tanks1[i].coordinationX;
                        tanks1[i + 2].coordinationY = tanks1[i].coordinationY + 4;
                    }

                    else
                    {  
                        tanks1[i + 2].coordinationX = tanks1[i].coordinationX;
                        tanks1[i + 2].coordinationY = tanks1[i].coordinationY + 4;
                    }                    
                }

                //Thread.Sleep(100);

            }

            Console.WriteLine("\n\n");
            Console.WriteLine($"Итог сражения для игрока {p1._Name}: набрал(а) {p1._score} очка(ов)");
            Console.WriteLine($"Итог сражения для игрока {p2._Name}: набрал(а) {p2._score} очка(ов)");

            string nameWinner;            

            if (p1._score > p2._score)
            {
                nameWinner = p1._Name;                
            }

            else if (p1._score == p2._score)
            {
                nameWinner = "Нет победителя";
            }

            else
            {
                nameWinner = p2._Name;
            }

            Console.WriteLine($"Победитель {nameWinner}");

            Console.WriteLine("\n\n\n\n");
        }
    }
}
