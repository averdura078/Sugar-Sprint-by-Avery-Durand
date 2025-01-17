using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Sugar Sprint game by Avery Durand
//FINAL PROJECT ICS3U
//Mr. T

namespace Sugar_Sprint_by_Avery_Durand
{
    public partial class Form1 : Form
    {
        //ground
        Rectangle ground = new Rectangle(0, 350, 550, 100);
        SolidBrush greenBrush = new SolidBrush(Color.SpringGreen);

        //player
        Rectangle chef = new Rectangle(10, 335, 20, 20);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        int chefSpeed = 10;
        int jumpUpOrDown= 0;

        //obstacles

        //falling obstacles

        //candies

        //keys
        bool leftPressed = false;
        bool rightPressed = false;
        bool jumpPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
                case Keys.Up:
                    jumpPressed = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
                case Keys.Space:
                    if (jumpPressed == false)
                    {
                        jumpPressed = true;
                    }
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(greenBrush, ground);
            e.Graphics.FillRectangle(yellowBrush, chef);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move player
            if (rightPressed == true && chef.X < this.Width - chef.Width)
            {
                chef.X += chefSpeed;
            }
            if (leftPressed == true && chef.X > 0)
            {
                chef.X -= chefSpeed;
            }
            if (jumpPressed == true)
            {
                jumpUpOrDown++;
                if (jumpUpOrDown < 5)
                {
                    //up
                    chef.Y -= chefSpeed;
                }
                if (jumpUpOrDown > 5)
                {
                    //down
                    chef.Y += chefSpeed;
                }
                
            }

            Refresh();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //start game
            gameTimer.Start();

            //hide menu
            titleLabel.Visible = false;
            enterNameLabel.Visible = false;
            nameInput.Visible = false;
            startButton.Visible = false;
            instructionsButton.Visible = false;

            //show name
            chefNameLabel.Text += " " + Convert.ToString(nameInput.Text);
            chefNameLabel.Visible = true;

            this.Focus();
        }

        private void instructionsButton_Click(object sender, EventArgs e)
        {

        }

    }
}
