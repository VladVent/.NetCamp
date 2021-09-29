using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum Suit {
        Трефа,
        Піка,
        Чирва,
        Бубна };

    public class Player
    {
       public string Name { get; set; }
    }
    public class Card: IEquatable<Card>
    {
        //public Suit suit;
        public int numbers;

        public bool Equals(Card other)
        {
            throw new NotImplementedException();
        }
    }
    public class Deck
    { 
        public  List<Card> card = new List<Card>();
        public int GetCard()
        {
            for (var i = 2; i <= 10; i++)
            {
                card.Add(new Card { numbers = i });
            }
            return 0;
        }
       
        public  void ChangeDeck()
            {
            Random rand = new Random();
            rand.Next(GetCard());
            Console.WriteLine(rand.ToString());
            }
        public void RozdatyCards()
        {

        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            
           Deck deck = new Deck();
           deck.GetCard();
           deck.ChangeDeck();
           Console.ReadKey();
        }
    }
}
