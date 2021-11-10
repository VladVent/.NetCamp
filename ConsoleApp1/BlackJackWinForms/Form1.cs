using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ConsoleApp1.Logic;
using System.Collections.Generic;

namespace BlackJackWinForms
{
    public partial class Form1 : Form
    {
        private int pointX = -50;
        private TableSession session;
        private PlayerState human;
        private PictureBox pictureBox;
        private List<PictureBox> listPictureBoxes;
        private DirectoryInfo di = new DirectoryInfo(@"../../Resources");


        public Form1()
        {
            InitializeComponent();
        }

        private List<PictureBox> ShowCardsAfterEndRound(PlayerState player)
        {
            FileInfo[] fileInfo = di.GetFiles("*.png");
            listPictureBoxes = new List<PictureBox>();
            foreach (var p in fileInfo)
            {
                var result = Path.GetFileNameWithoutExtension(p.Name);
                foreach (var c in player.CardsInHands)
                {
                    if (result == c.ToString())
                    {
                        pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(p.FullName);
                        CreateDynamicPictureBoxView(pictureBox);
                    }
                }
            }
            PictureBoxViewSizes(pointX);
            return listPictureBoxes;
        }

        private List<PictureBox> PictureBoxViewSizes(int pointX)
        {
            foreach (var d in listPictureBoxes)
            {
                pointX = pointX + 100;
                d.Size = new System.Drawing.Size(164, 298);
                d.SizeMode = PictureBoxSizeMode.StretchImage;
                d.Location = new Point(pointX, 100);
            }

            return listPictureBoxes;
        }

        private List<PictureBox> CreateDynamicPictureBoxView(PictureBox picBox)
        {
            Controls.Add(picBox);
            listPictureBoxes.Add(picBox);

            return listPictureBoxes;
        }

        private void StartWinForm(object sender, EventArgs e)
        {
            Restart();
        }

        private void PlayerTakeCardClick(object sender, EventArgs e)
        {
            session.PlayerTakeCard(human);
            RefreshButtons();
        }

        private void RefreshButtons()
        {
            button1.Enabled = human.state == PlayerInGameState.IamThinking;
            var winnersAvailable = session.GetState().Players.Any(x => x.state == PlayerInGameState.IamWon);
            bool iAmLost = human.state == PlayerInGameState.IamLost;
            this.score.Text = $"{human.SumPoint} {human.state} \r\n Bot Score:" + bot.SumPoint + " " + bot.state;
            button2.Enabled = !iAmLost && !winnersAvailable;

            if (human.state != PlayerInGameState.IamThinking)
                ShowCardsAfterEndRound(human);
            if (bot.state != PlayerInGameState.IamThinking)
            {
                pointX = 400;
                ShowCardsAfterEndRound(bot);
            }

        }
        private void PlayerWouldLikeStopClick(object sender, EventArgs e)
        {
            session.PlayerWouldLikeStop(human);
            RefreshButtons();
        }

        private void RestartClick(object sender, EventArgs e)
        {

            label2.Text = session.RoundNumber.ToString();
            session.RestartSession();
            CleanCardFace(human);
            CleanCardFace(bot);
            RefreshButtons();
        }

        private void CleanCardFace(PlayerState playerState)
        {
                foreach (var l in listPictureBoxes)
                {
                    l.Dispose();
                    pictureBox.Dispose();
                }
                listPictureBoxes.Clear();

        }

        private PlayerState bot;
        private void Restart()
        {

            session = new TableSession(Environment.TickCount);
            human = session.Join("Human");
            bot = session.Join("BOT");
            RefreshButtons();

        }

        private void TestBotIsReadyClick(object sender, EventArgs e)
        {
            session.PlayerWouldLikeStop(bot);
            RefreshButtons();
        }
    }
}