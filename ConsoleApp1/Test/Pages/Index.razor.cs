using Microsoft.AspNetCore.Components;

namespace SingleBlazorBlackJack.Pages
{
    public class IndexModel : ComponentBase
	{
		[Inject]
		public NavigationManager NavigationManager { get; set; }
		public string identity { get; set; }

		[Inject]
		public  BlackJackMultSessions BlackJack { get; set; }
		public void Navigator(string identity)
		{
			BlackJack.GetPlayerAndSession(identity);
			NavigationManager.NavigateTo(String.Format("TableSessionPage/{0}", identity));
		}
	}
}