﻿namespace BlackJackWinForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.HumanDecideTakeACard = new System.Windows.Forms.Button();
            this.HumanDecideToStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxArray1 = new Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArray1)).BeginInit();
            this.SuspendLayout();
            // 
            // HumanDecideTakeACard
            // 
            this.HumanDecideTakeACard.Location = new System.Drawing.Point(77, 531);
            this.HumanDecideTakeACard.Name = "HumanDecideTakeACard";
            this.HumanDecideTakeACard.Size = new System.Drawing.Size(107, 70);
            this.HumanDecideTakeACard.TabIndex = 0;
            this.HumanDecideTakeACard.Text = "TAKE MORE";
            this.HumanDecideTakeACard.UseVisualStyleBackColor = true;
            this.HumanDecideTakeACard.Click += new System.EventHandler(this.PlayerTakeCardClick);
            // 
            // HumanDecideToStop
            // 
            this.HumanDecideToStop.Location = new System.Drawing.Point(301, 531);
            this.HumanDecideToStop.Name = "HumanDecideToStop";
            this.HumanDecideToStop.Size = new System.Drawing.Size(107, 70);
            this.HumanDecideToStop.TabIndex = 0;
            this.HumanDecideToStop.Text = "STOP";
            this.HumanDecideToStop.UseVisualStyleBackColor = true;
            this.HumanDecideToStop.Click += new System.EventHandler(this.PlayerWouldLikeStopClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Location = new System.Drawing.Point(100, 71);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(43, 16);
            this.score.TabIndex = 1;
            this.score.Text = "Score";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1269, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 70);
            this.button3.TabIndex = 0;
            this.button3.Text = "Restart";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.RestartClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1269, 531);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 70);
            this.button4.TabIndex = 0;
            this.button4.Text = "BOT STOP";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.TestBotIsReadyClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Score";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(54, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1247, 384);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 604);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.score);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.HumanDecideToStop);
            this.Controls.Add(this.HumanDecideTakeACard);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArray1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HumanDecideTakeACard;
        private System.Windows.Forms.Button HumanDecideToStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray pictureBoxArray1;
        private System.Windows.Forms.Panel panel1;
    }
}

