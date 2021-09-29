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
    public class Card
    {
        public int numbers { get; set; }
    }
    public class Deck
        {
        
        public List<Card> cards = new List<Card>();
        public List<Card> GetCard()
        {
            return cards;
        }
       
        public  void ChangeDeck()
            {
            Console.WriteLine(cards);
            }

       
    }
    class Program
    {
        static void Main(string[] args)
        {
           
            Deck deck = new Deck();
           Console.WriteLine(deck.GetCard());
           deck.ChangeDeck();
            Console.ReadKey();
        }
    }
}
