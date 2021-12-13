using Microsoft.AspNetCore.Components;
using BlackJack.Logic;
using BlackJack.Domain.Logic;
using BlackJack.DAL.Services;
using AutoMapper;
using BlackJack.DAL.Models;
using BlackJack.DAL.Context;
#pragma warning disable CS8603 // Possible null reference return.

namespace BlackJackBlazor.Pages
{
    public class TableSessionsPage : ComponentBase
    {
        public int Count = 5;


        [Parameter]
        public string cardFace { get; set; }
        [Parameter]
        public string? Identity { get; set; }
        [Inject]
        private ICasinoService _service { get; set; }

        [Inject]
        private ApplicationContext application { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public Desk? desk { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
            base.OnInitialized();
            desk = Casino.JoinPlayer(Identity);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PlayerState, PlayerDB>());
            var mapper = new Mapper(config);
            var DeskDAL = mapper.Map<PlayerState, PlayerDB>(StateOfPlayers().FirstOrDefault(x=>x.PlayerName == Identity));

            _service.Create(DeskDAL);
            // _service.Update(DeskDAL);
            application.SaveChanges();

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

       
        public void GetCardName() => StateOfPlayers().ForEach(x => x.CardsInHands.ToString());

        public PlayerState GetPlayer() => StateOfPlayers().FirstOrDefault(x => x.PlayerName == Identity);
        public PlayerState GetEnemy() => StateOfPlayers().FirstOrDefault(x => x.PlayerName != Identity);
        public bool IsAnyPlayerWinOrLose() => StateOfPlayers().Any(x => x.State == PlayerInGameState.IamWon || x.State == PlayerInGameState.IamLost);

       
    }
}