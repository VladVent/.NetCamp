using Microsoft.AspNetCore.Components;
using BlackJack.Logic;
using BlackJack.Domain.Logic;

namespace BlackJackBlazor.Pages
{
    public class TableSessionsPage : ComponentBase
    {
        [Parameter]
        public string? Identity { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public Desk? desk { get; set; }

        public int? counter = 5;
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
    }
}