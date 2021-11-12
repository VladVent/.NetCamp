using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BlackJack.Logic;
using System.Collections.Generic;

namespace BlackJackWinForms
{
    public partial class Form1 : Form
    {

        private TableSession session;
        private PlayerState human;
        private PlayerState bot;
        Dictionary<string, Stream> cardToStream;



        public Form1()
        {
            InitializeComponent();
            cardToStream = CreateCardsCache();           
           
            CreateDemoSession();            
        }

        private void CreateDemoSession()
        {
            session = new TableSession(Environment.TickCount);
            human = session.Join("Human");
            bot = session.Join("BOT");
        }

        private static Dictionary<string, Stream> CreateCardsCache()
        {
            var files = new DirectoryInfo(@"../../Resources").GetFiles();
            var cache =  new Dictionary<string, Stream>(StringComparer.OrdinalIgnoreCase);
            foreach (var file in files)
            {
                var fileWithoutExtension = Path.GetFileNameWithoutExtension(file.Name);
                var memStream = new MemoryStream(File.ReadAllBytes(file.FullName));
                cache[fileWithoutExtension] = memStream;
            }
            return cache;
        }



        private void DrawSessionCards()
        {

            ClearVisibleCards();


            const int CardWidth = 100;

            int margin = 50;

            DrawCards(human);
            margin = 650;
            DrawCards(bot);

            void DrawCards(PlayerState state)
            {
                foreach (var c in state.CardsInHands)
                {
                    string key = "CardBack";
                    if (state == bot && state.state != PlayerInGameState.IamThinking || state == human)
                        key = c.ToString();


                    var pictureBox = new PictureBox
                    {
                        Image = Image.FromStream(cardToStream[key]),
                        Size = new Size(164, 298),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Location = new Point(margin, 0),
                        Parent = panel1,
                    };
                    margin += CardWidth;

                }
            }
        }





        private void PlayerTakeCardClick(object sender, EventArgs e)
        {
            session.PlayerTakeCard(human);
            RefreshButtonsStates();
            DrawSessionCards();
        }

        private void RefreshButtonsStates()
        {
            HumanDecideTakeACard.Enabled = human.state == PlayerInGameState.IamThinking;
            var winnersAvailable = session.GetState().Players.Any(x => x.state == PlayerInGameState.IamWon);
            bool iAmLost = human.state == PlayerInGameState.IamLost;
            score.Text = $"{human.SumPoint} {human.state} \r\n Bot Score:" + bot.SumPoint + " " + bot.state;
            HumanDecideToStop.Enabled = !iAmLost && !winnersAvailable;
        }
        private void PlayerWouldLikeStopClick(object sender, EventArgs e)
        {
            session.PlayerWouldLikeStop(human);
            RefreshButtonsStates();
        }

        private void RestartClick(object sender, EventArgs e)
        {
            label2.Text = session.RoundNumber.ToString();
            session.RestartSession();
            RefreshButtonsStates();
            DrawSessionCards();
        }



        private void ClearVisibleCards()
        {
            panel1.Controls.Clear();
        }



       
        private void TestBotIsReadyClick(object sender, EventArgs e)
        {
            session.PlayerWouldLikeStop(bot);
            RefreshButtonsStates();
            DrawSessionCards();
        }
    }
}