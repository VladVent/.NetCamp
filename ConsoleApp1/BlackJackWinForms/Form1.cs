using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ConsoleApp1.Logic;

namespace BlackJackWinForms
{
    public partial class Form1 : Form
    {
        private TableSession session;
        private PlayerState human;
        private PictureBox pictureBox;

        public Form1()
        {
            InitializeComponent();
        }

        private void CardsFace()
        {
            DirectoryInfo di = new DirectoryInfo(@"D:\.NetCamp\ConsoleApp1\BlackJackWinForms\Resources\");
            FileInfo[] fileInfo = di.GetFiles("*.png");
            pictureBox = new PictureBox();
            pictureBox1.Image = null;
            foreach (var c in human.CardsInHands)
            {
                foreach (var p in fileInfo)
                {
                    var result = Path.GetFileNameWithoutExtension(p.Name);
                    if (result == c.ToString())
                    {
                        if(pictureBox1.Image == null)
                            pictureBox1.Image = Image.FromFile(p.FullName);
                        else
                            pictureBox2.Image = Image.FromFile(p.FullName);
                    }
                }
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