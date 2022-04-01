using BlackJack.DAL.Services;
using Microsoft.AspNetCore.Components;
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace SingleBlazorBlackJack.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public ICasinoService _service { get; set; }
        public string? identity { get; set; }
        public void Navigator(string identity)
        {
            NavigationManager.NavigateTo(String.Format("TableSessionPage/{0}", identity));
        }
    }
}
