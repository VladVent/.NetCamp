namespace ConsoleApp1
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

		public Card(CardSuit cardSuit, string name, int power)
		{
			Name = name.ToUpper();
			CardSuit = cardSuit;
			Power = power;
		}
        
	}
}