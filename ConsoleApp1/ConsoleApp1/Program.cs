using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum Suit
    {
        Трефа,
        Піка,
        Чирва,
        Бубна
    };

    public class Player
    {
        public string Name { get; set; }
    }
    public class Card
    {
        //public Suit suit;
        public int numbers;
    }
    public class Deck
    {
        public static List<Card> CreateCards()
         {
            List<Card> card = new List<Card>();
            for (var i = 2; i <= 10; i++)
            {
                card.Add(new Card { numbers = i });
                Console.WriteLine( card.GetEnumerator());
            }
            return card;
        }
        public void ShuffleDeck()
        {
            Random rand = new Random();
            rand.Next(CreateCards().Count);
        }
        public int RozdatyCards()
        {
            return 0;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            var deck = Deck.CreateCards();
            Console.WriteLine(deck);
            Console.ReadKey();
        }
    }
}
