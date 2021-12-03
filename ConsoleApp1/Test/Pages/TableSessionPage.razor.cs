using Microsoft.AspNetCore.Components;
using BlackJack.Logic;
using SingleBlazorBlackJack;


namespace BlackJackBlazor.Pages
{
    public class TableSessionsPage : ComponentBase
    {
        [Parameter]
        public string? Identity { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public BlackJackMultSessions BlackJack { get; set; }


     
        public List<PlayerState> State()
        {
            return BlackJack.tableSession.players;
        }
        public void TakeCardClick()
        {
            BlackJack.TakeCard(Identity);
        }
        public void StopTakeClick()
        {
           BlackJack.PlayerStop(Identity);
        }

        public void RestartRoundClick()
        {
            BlackJack.RestartRound();
        }
    }
}