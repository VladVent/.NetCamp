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
        public void GetCard()
        {
            List<Card> card = new List<Card>();
            for (var i = 1; i > 11; i++)
            {
                card.Add(new Card { numbers = i });
            Console.WriteLine(card[i]);
            }
        }
       
        public  void ChangeDeck()
            {
            Random rand = new Random();

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
