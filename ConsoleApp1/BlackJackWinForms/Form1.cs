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

        private void CardsFace()
        {
            FileInfo[] fileInfo = di.GetFiles("*.png");

            listPictureBoxes = new List<PictureBox>();
            pictureBox = new PictureBox();

            CreateDynamicPictureBox(pictureBox);
            PictureBoxSizes(pointX);
            ShowCardsAfterEndRound(fileInfo);
        }

        private void ShowCardsAfterEndRound(FileInfo[] fileInfo)
        {
            foreach (var p in fileInfo)
            {
                var result = Path.GetFileNameWithoutExtension(p.Name);
                foreach (var c in human.CardsInHands)
                {
                    if (result == c.ToString())
                    {
                        result.Count();
                        foreach (var pi in listPictureBoxes)
                        {
                            pi.Image = Image.FromFile(p.FullName);
                        }
                    }

                }

            }
        }

        private int PictureBoxSizes(int pointX)
        {
            foreach (var d in listPictureBoxes)
            {
                pointX = pointX + 100;
                d.Size = new System.Drawing.Size(164, 298);
                d.SizeMode = PictureBoxSizeMode.StretchImage;
                d.Location = new Point(pointX, 100);
            }

            return pointX;
        }

        private void CreateDynamicPictureBox(PictureBox picBox)
        {
            for (var i = 0; i < human.CardsInHands.Count(); i++)
            {
                Controls.Add(picBox);
                listPictureBoxes.Add(picBox);

            }
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
            button1.Enabled = human.state == SuslikState.IamThinking;
            var winnersAvailable = session.GetState().Players.Any(x => x.state == SuslikState.IamWon);
            bool iAmLost = human.state == SuslikState.IamLost;
            this.score.Text = $"{human.SumPoint} {human.state} \r\n Bot Score:" + bot.SumPoint + " " + bot.state;
            button2.Enabled = !iAmLost && !winnersAvailable;

            if (human.state == SuslikState.IamDoneTakingCards || human.state == SuslikState.IamWon)
                CardsFace();
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