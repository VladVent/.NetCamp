using System;

namespace ConsoleApp1
{
    public class GameCleanWin: IGameRuleState
    {
        public void CleanWin()
        {
            Console.WriteLine("GG EZ!!!!");
        }

        public void GameOver()
        {
            Console.WriteLine("U Lose!");
        }

        public void Win()
        {
            Console.WriteLine($"Win!");
        }

    }
}