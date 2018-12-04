using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping_Pong_Game
{
    public partial class Form1 : Form
    {
        private int speed_left = 3;
        private int speed_top = 3;
        private int point = 0;

        public Form1()
        {
            InitializeComponent();


            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            racket.Top = playground.Bottom - (playground.Bottom / 10);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);
            ball.Left += speed_left;
            ball.Top += speed_top;
            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Right >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;
                point += 1;
            }
            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
           if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
           if (ball.Top <= playground.Top)
            {
                speed_top = -speed_left;
            }
            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
            }
          
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
