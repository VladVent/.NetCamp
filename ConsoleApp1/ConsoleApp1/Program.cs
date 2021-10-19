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
        Two,
        Tree,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace 
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
        public Card(Suit suit, Cards oldestCard)
        {
            this.suit = suit;
            this.oldestCard = oldestCard;
            switch (oldestCard)
            {
                case Cards.Two:
                    numbers = 2;
                    break;
                case Cards.Tree:
                    numbers = 3;
                    break;
                case Cards.Four:
                    numbers = 4;
                    break;
                case Cards.Five:
                    numbers = 5;
                    break;
                case Cards.Six:
                    numbers = 6;
                    break;
                case Cards.Seven:
                    numbers = 7;
                    break;
                case Cards.Eight:
                    numbers = 8;
                    break;
                case Cards.Nine:
                    numbers = 9;
                    break;
                case Cards.Ten:
                case Cards.Jack:
                case Cards.Queen:
                case Cards.King:
                    numbers = 10;
                    break;
                case Cards.Ace:
                    numbers = 11;
                    break;
            }

        }
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
                    card.Push(new Card((Suit) suit, (Cards) oldcard));
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
            cardinhand.Push(cards.Pop());
        }
    }


    public static class TableSessions
    {
        public static Stack<Player> players = new Stack<Player>();
        public static Stack<Card> deck = Deck.CreateCards();
        public static void Table()
        {
            Stack<Card> hanCards = new Stack<Card>();
            //deck.outputdesc();
            Deck.ShuffleDeck(deck);
            Console.WriteLine("Shuffle");
            Deck.CardsInHands(deck, hanCards);
            Console.WriteLine("CardInHand");
            hanCards.outputdesc();
            Deck.SumCards(deck);
            Console.WriteLine($"Sum: {Deck.SumCards(hanCards)}");
            Console.WriteLine("TakeCard");
            Deck.TakeCard(deck, hanCards);
            hanCards.outputdesc();
            Console.WriteLine(hanCards.Count);
            Console.WriteLine($"Sum: {Deck.SumCards(hanCards)}");
        }

        public static void Turn()
        {

        }
        public static void Join(Player player)
        {
            players.Push(player);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TableSessions.Table();
            Player p1 = new Player() {Name = "TempName"};
            TableSessions.Join(p1);
            Player p2 = new Player() {Name = "Eve" };
            TableSessions.Join(p2);
            TableSessions.players.Out();
            Console.ReadKey();
        }
    }
}
