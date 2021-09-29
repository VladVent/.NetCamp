using ConsoleApp1.Extensions;
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
            }
            return card;
        }
        public static void ShuffleDeck(ref List<Card> cards)
        {
            Random rand = new Random();
            cards = cards.OrderBy(x => rand.Next()).ToList();
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
            deck.outputdesc();
            Deck.ShuffleDeck(ref deck);
            deck.outputdesc();
            Console.ReadKey();
        }
    }
}
