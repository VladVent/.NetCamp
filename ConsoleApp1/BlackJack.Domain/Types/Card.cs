namespace BlackJack.Types
{
    public class Card
    {
        public CardSuit CardSuit;
        public int Power;
        public string Name;

        public override string ToString()
        {
            return $"{Name} {CardSuit}";
        }
        public Card(CardSuit cardSuit, string stName, CardName power)
        {
            Name = stName.ToUpper();
            CardSuit = cardSuit;
            Power = (int) power;
        }
    }
}