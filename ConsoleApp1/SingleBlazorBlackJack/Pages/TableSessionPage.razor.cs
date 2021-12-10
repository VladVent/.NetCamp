using Microsoft.AspNetCore.Components;
using BlackJack.Logic;
using BlackJack.Domain.Logic;
#pragma warning disable CS8603 // Possible null reference return.

namespace BlackJackBlazor.Pages
{
    public class TableSessionsPage : ComponentBase
    {
        [Parameter]
        public string? Identity { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public Desk? desk { get; set; }
        protected override async Task OnInitializedAsync()
        {

            desk = Casino.JoinPlayer(Identity);
            desk.DeskStateUpdated += async (sender, a) => { await InvokeAsync(() => StateHasChanged()); };
            await base.OnInitializedAsync();

        }
        public List<PlayerState> StateOfPlayers() => desk.GetArrayPlayers();
        public void TakeCardClick()
        {
            desk.TakeCard(Identity);
        }
        public void StopTakeClick()
        {
            desk.PlayerStop(Identity);
        }

        public PlayerState GetPlayer()
        {
            return StateOfPlayers().FirstOrDefault(x => x.Name == Identity);
        }

        public PlayerState GetEnemy()
        {
           return StateOfPlayers().FirstOrDefault(x => x.Name != Identity);
        }

        public bool IsEnemyWin()=>  GetEnemy().State == PlayerInGameState.IamWon;
        public bool IsEnemyLost() => GetEnemy().State == PlayerInGameState.IamLost;


    }
}