using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1.Logic;

namespace BlackJackWinForms
{
    public partial class Form1 : Form
    {
        private TableSession session;
        private PlayerState human;

        public Form1()
        {
            InitializeComponent();
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

            this.score.Text = $"{human.SumPoint} {human.state} \r\n Bot Score:"+bot.SumPoint+" " + bot.state;
            button2.Enabled = !iAmLost && !winnersAvailable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            session.PlayerWouldLikeStop(human);


            RefreshButttons();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Restart();
        }


        private PlayerState bot;
        private void Restart()
        {
            session = new TableSession(Environment.TickCount);
            human = session.Join("Human");
            bot=session.Join("BOT");
            RefreshButttons();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            session.PlayerWouldLikeStop(bot);
            RefreshButttons();

        }
    }
}