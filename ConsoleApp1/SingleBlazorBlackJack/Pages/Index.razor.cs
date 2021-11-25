using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using SingleBlazorBlackJack;
using SingleBlazorBlackJack.Shared;
using System.Drawing;

namespace SingleBlazorBlackJack.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public BlackJackMultSessions blackJack { get; set; } = new BlackJackMultSessions();
        public string identity { get; set; }

        public string name { get; set; }
        public string sumscore { get; set; }
        public string state { get; set; }

        public Queue<string> SourceName = new Queue<string>();

        Dictionary<string, Stream> cardToStream = CreateCardsCache();
        private static Dictionary<string, Stream> CreateCardsCache()
        {
            var files = new DirectoryInfo(@"../../Resources").GetFiles();
            var cache = new Dictionary<string, Stream>(StringComparer.OrdinalIgnoreCase);
            foreach (var file in files)
            {
                var fileWithoutExtension = Path.GetFileNameWithoutExtension(file.Name);
                var memStream = new MemoryStream(File.ReadAllBytes(file.FullName));
                cache[fileWithoutExtension] = memStream;
            }
            return cache;
        }


        public void AddPlayers(string identity)
        {
            SourceName.Enqueue(identity);
            blackJack.AddPlayersInSessions(identity);
            GetStatusPlayer();
        }

        private void GetStatusPlayer()
        {
            foreach (var p in blackJack.tableSession.players)
            {
                name = p.Name;
                sumscore = p.SumPoint.ToString();
                state = p.State.ToString();
            }
        }

        public void PlayerTakeCardClick(string identity)
        {

            blackJack.PlayerWouldLikeTakeCard(identity);
            GetStatusPlayer();
        }

        public void StopTakeCardClick(string identity)
        {
            var player = SourceName
                .Where(x => x != identity)
                .FirstOrDefault();
             var id = SourceName
                .Where(x => x == identity)
                .FirstOrDefault();
                if (player != identity)
                {
                identity = player;
                blackJack.PlayerWouldLikeStop(identity);
                }
                else
                {
                    blackJack.PlayerWouldLikeStop(id);
                }

            GetStatusPlayer();
        }

        public void RestartRound(string identity)
        {
            blackJack.RestartRound(identity);
            GetStatusPlayer();
        }
    }
}