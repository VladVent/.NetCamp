using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Player
    {
       public string Name { get; set; }
    }

    public class Card
        {
        }

    class Program
    {
        static void Main(string[] args)
        {
     
            string player = new Player().ToString();
            Console.WriteLine("Вiтаю, ви граєте в BlackJack");
            Console.WriteLine("Введіть ваше ім'я");
            player = Console.ReadLine();
            Console.WriteLine($"Вітаю вас {player}");
            int a = 21;
            Console.WriteLine(a);
            if (a == 21)
            {
                Console.WriteLine("Ви виграли");
            }
            else
            {
                Console.WriteLine("Ви програли");
            }
            Console.ReadKey();
        }
    }
}
