using ConsoleApp1.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
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
    public enum Cards
    {
        Two = 2,
        Tree = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
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
        public Cards oldestCard;
    }
    public static class Deck
    {
        public static Stack<Card> CreateCards()
        {
            Stack<Card> card = new Stack<Card>();
            foreach (var suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (var oldcard in Enum.GetValues(typeof(Cards)))
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
        public static Stack<Card> CardsInHands(this Stack<Card> cards, Stack<Card> cardinhand)
        {
            //Stack<Card> card = new Stack<Card>();
            for (var i = 0; i < 2 && cards.Count > 0; i++)
            {
                cardinhand.Push(cards.Pop());
            }
            return cardinhand;
        }

        public static int SumCards(this Stack<Card> cards)
        {
            int a = 0;
            a = cards.Sum(x => x.numbers);
            return a;
        }

        public static void TakeCard(this Stack<Card> cards, Stack<Card> cardinhand) //Тут звернути увагу
        {
            var sum = Deck.SumCards(cardinhand);

            while (sum <= 28)
            {
                if (sum <= 21)
                {

                    cardinhand.Push(cards.Pop());
                    sum = Deck.SumCards(cardinhand);
                }
                else
                {
                    Console.WriteLine("U Lost!!!!!");
                    break;
                }
            }
        //return cardinhand;
        }
    }


    public static class TableSessions
    {
        public static List<Player> players;
        public static Stack<Card> deck = Deck.CreateCards();
        public static void Table()
        {
            Stack<Card> hanCards = new Stack<Card>();
            Deck.ShuffleDeck(deck);
            Console.WriteLine("Shuffle");
            Deck.CardsInHands(deck, hanCards);
            Console.WriteLine("CardInHand");
            hanCards.outputdesc();
            Deck.SumCards(deck);
            Console.WriteLine($"Sum: {Deck.SumCards(hanCards)})");
            Console.WriteLine("TakeCard");
            Deck.TakeCard(deck, hanCards);
            hanCards.outputdesc();
            Console.WriteLine(hanCards.Count);
            Console.WriteLine(Deck.SumCards(hanCards));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TableSessions.Table();
            Console.ReadKey();
        }
    }
}
