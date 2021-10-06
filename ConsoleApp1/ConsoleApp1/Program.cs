using ConsoleApp1.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public enum Suit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    };
    public enum OldestCard
    {
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    };



    public class Player
    {
        public string Name { get; set; }
    }
    public class Card
    {
        public Suit suit;
        public int numbers;
        public OldestCard oldestCard;
    }
    public static class Deck
    {
        public static Stack<Card> CreateCards()
        {
            Stack<Card> card = new Stack<Card>();
            foreach (var suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (var oldcard in Enum.GetValues(typeof(OldestCard)))
                {
                    for (var i = 2; i <= 14; i++)
                    {
                        card.Push(new Card { numbers = i, suit = (Suit)suit });
                    }
                    break;
                }
            }
            return card;
        }
        public static Stack<Card> ShuffleDeck(this Stack<Card> cards)
        {
            Random rand = new Random();
            var values = cards.ToArray();
            cards.Clear();
            foreach (var value in values.OrderBy(x => rand.Next()))
                cards.Push(value);
            return new Stack<Card>(cards.OrderBy(x => rand.Next()));
        }
        public static Stack<Card> CardsInHands(this Stack<Card> cards)
        {
            Stack<Card> card = new Stack<Card>();
            for (var i = 0; i < 2; i++)
            {
                card.Push(cards.Pop());
            }
            return card;
        }

        public static int SumCards(this Stack<Card> cards)
        {
            int a = 0;
            a = cards.Sum(x => x.numbers);
            return a;
        }
    }


    public static class TableSessions
    {
        public static List<Player> players;
        public static Stack<Card> deck = Deck.CreateCards();

    }

    class Program
    {
        static void Main(string[] args)
        {
            var deck = Deck.CreateCards();
            //deck.outputdesc();
            Deck.ShuffleDeck(deck);
            //Console.WriteLine("Shuffle");
            //deck.outputdesc();
            Console.WriteLine(Deck.CardsInHands(deck));
            Console.WriteLine("CardInHand");
            //deck.outputdesc();
            Deck.SumCards(deck);
            //Console.WriteLine(deck.Count);
            //Console.WriteLine("Sum");
            Console.WriteLine(Deck.SumCards(deck));

            Console.ReadKey();
        }
    }
}
