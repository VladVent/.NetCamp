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
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(p.FullName);
                        CreateDynamicPictureBox(pictureBox);
                    }
                }
            }
            PictureBoxSizes(pointX);
            return listPictureBoxes;
        }

        private List<PictureBox> PictureBoxSizes(int pointX)
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

        private List<PictureBox> CreateDynamicPictureBox(PictureBox picBox)
        {
            Controls.Add(picBox);
            listPictureBoxes.Add(picBox);

            return listPictureBoxes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            session.PlayerTakeCard(human);
            RefreshButttons();
        }

        private void RefreshButttons()
        {
            button1.Enabled = human.state == PlayerThinksState.IamThinking;
            var winnersAvailable = session.GetState().Players.Any(x => x.state == PlayerThinksState.IamWon);
            bool iAmLost = human.state == PlayerThinksState.IamLost;
            this.score.Text = $"{human.SumPoint} {human.state} \r\n Bot Score:" + bot.SumPoint + " " + bot.state;
            button2.Enabled = !iAmLost && !winnersAvailable;

            if (human.state == PlayerThinksState.IamDoneTakingCards || human.state == PlayerThinksState.IamWon || human.state == PlayerThinksState.IamLost)
                ShowCardsAfterEndRound(human);
            if (bot.state == PlayerThinksState.IamDoneTakingCards || bot.state == PlayerThinksState.IamWon || bot.state == PlayerThinksState.IamLost)
            {
                pointX = 400;
                ShowCardsAfterEndRound(bot);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            session.PlayerWouldLikeStop(human);
            RefreshButttons();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            label2.Text = session.RoundNumber.ToString();
            session.RestartSession();
            RefreshButttons();
            //Restart();
        }


        private PlayerState bot;
        private void Restart()
        {

            session = new TableSession(Environment.TickCount);
            human = session.Join("Human");
            bot = session.Join("BOT");
            RefreshButttons();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            session.PlayerWouldLikeStop(bot);
            RefreshButttons();

        }



        private void fileInfo1_Click(object sender, EventArgs e)
        {

        }

        private void fileInfo4_Click(object sender, EventArgs e)
        {

        }
    }
}