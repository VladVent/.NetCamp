namespace ConsoleApp1.Types
{
    public class Card
    {
        public CardSuit CardSuit;
        public int Power;
        public string Name;

        public override string ToString()
        {
            return $"{Name} {CardSuit}: {Power}";
        }
        public Card(CardSuit cardSuit, CardName name)
        {
            Name = name.ToString().ToUpper();
            CardSuit = cardSuit;
            Power = (int) name;
        }
    }
}