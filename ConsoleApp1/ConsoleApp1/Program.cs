using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Player
    {
        string Name;
    }

    public class Card
        {
        }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 21;
            Console.WriteLine(a);
            Console.WriteLine("Вiтаю, ви граєте в BlackJack");
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
