namespace ConsoleApp1
{
     public interface IGameRuleState
    {
        void CleanWin();
        void GameOver();
        void Win();
    }
}