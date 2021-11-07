using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Linq.Expressions;
//using System.Drawing.Imaging;

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

        //private Color color;

        //public Color TankColor
        //{
        //    get { return color; }
        //    set { color = Color.Cyan; }
        //}

        public Color color { get; set; }

        public abstract void Print();

        public override string ToString()
        {
            Console.ForegroundColor = (ConsoleColor)color;

            return $"Танк: {Name}\n" +
            $"Боекомплект танка: {Ammunition}\n" +
                $"Уровень брони: {HP}\n" +
                $"Маневренность: {Maneuverability}";
               // $"Color: {color}" ;            
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
            // Console.ForegroundColor = (ConsoleColor)color;
            
            return base.ToString();
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
            // Console.ForegroundColor = (ConsoleColor)color;

            return base.ToString();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "WordOfTanks";
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.ForegroundColor = ConsoleColor.DarkGreen;

            //int amunition, hp, maneuverability;
            Random rnd = new Random();

            Player p1 = new Player("Марго", 0);
            p1.name = nameof(p1);
            Player p2 = new Player("Александр", 0);
            p2.name = nameof(p2);

            Random rnd2 = new Random();

            Tank tank1 = new T34(p1, rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));
            Tank tank2 = new Pantera(p2, rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));

            Tank[] tanks = new Tank[] { tank1, tank2 };

            Tank[] tanks1 = new Tank[12];

           

            for (int i = 0; i < tanks1.Length; i+=2)
            {
                double trueProbability = 0.2;
                bool result = rnd.NextDouble() < trueProbability;

                if (result)
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

                else
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

            }

            for (int i = 0; i < tanks1.Length; i++)
            {
                tanks1[i].Print();
              
               if (i < tanks1.Length - 2)
                {
                    if (i % 10 == 0)
                    {
                        tanks1[i + 2].coordinationX = tanks1[i].coordinationX;
                        tanks1[i + 2].coordinationY = tanks1[i].coordinationY + 2;
                    }

                    else
                    {
                        tanks1[i + 2].coordinationX = tanks1[i].coordinationX;
                        tanks1[i + 2].coordinationY = tanks1[i].coordinationY + 2;
                    }
                    
                }        
                
                
            }

            //foreach (var item in tanks1)
            //{
                
            //    item.Print();
            //}
            //tank1.Print();
            //Console.WriteLine(tank1);

            // tank2.Print();
            //Console.WriteLine(tank2);


            //Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
