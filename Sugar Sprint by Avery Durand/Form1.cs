using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

//Sugar Sprint game by Avery Durand
//FINAL PROJECT ICS3U
//Mr. T

namespace Sugar_Sprint_by_Avery_Durand
{
    public partial class Form1 : Form
    {
        //ground
        Rectangle ground = new Rectangle(0, 350, 550, 100);
        SolidBrush groundBrush = new SolidBrush(Color.SpringGreen);

        //player
        Rectangle chef = new Rectangle(10, 320, 30, 30);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        int chefSpeed = 12;
        int chefScore = 0;
        int highScore = 0;
        int jumpUpOrDown = 0;

        //blades
        List<Rectangle> blades = new List<Rectangle>();
        SolidBrush grayBrush = new SolidBrush(Color.Gray);

        //falling obstacles
        List<Rectangle> broccolis = new List<Rectangle>();
        SolidBrush lightGreenBrush = new SolidBrush(Color.LightGreen);
        SolidBrush greenBrush = new SolidBrush(Color.Green);

        //candies
        List<Rectangle> candies = new List<Rectangle>();
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush lightYellowBrush = new SolidBrush(Color.LightYellow);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);

        //grass
        List<Rectangle> grass = new List<Rectangle>();
        SolidBrush grassBrush = new SolidBrush(Color.MediumSeaGreen);

        //keys
        bool leftPressed = false;
        bool rightPressed = false;
        bool jumpPressed = false;

        //random generator
        Random randGen = new Random();

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
                case Keys.Space:
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
            e.Graphics.FillRectangle(yellowBrush, chef);

            e.Graphics.FillRectangle(groundBrush, ground);
            //draw grass

            //draw blades

            //draw candies

            //draw broccoli
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
                if (jumpUpOrDown <= 20)
                {
                    //up
                    chef.Y -= chefSpeed / 2;
                }
                if (jumpUpOrDown > 20)
                {
                    //down
                    chef.Y += chefSpeed / 2;
                }
                if (jumpUpOrDown == 40)
                {
                    jumpUpOrDown = 0;
                    jumpPressed = false;
                }

            }

            //create blades

            //move blades

            //create broccolis

            //move broccolis

            //check for collision with blades

            //check for collision with broccolis

            //

            //refresh score
            scoreLabel.Text = $"Score: {chefScore}  High Score: {highScore}";
            if (chefScore > highScore)
            {
                highScore = chefScore;

                //show new high score message
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

            //show name, score, and menu button
            chefNameLabel.Text += " " + Convert.ToString(nameInput.Text);
            chefNameLabel.Visible = true;
            scoreLabel.Visible = true;
            menuButton.Visible = true;

            this.Focus();
        }

        private void instructionsButton_Click(object sender, EventArgs e)
        {
            //hide menu
            enterNameLabel.Visible = false;
            nameInput.Visible = false;
            startButton.Visible = false;
            instructionsButton.Visible = false;

            //show instructions and back button
            instructionsLabel.Text = "Welcome to Sugar Sprint, chef!\n\nCollect the rainbow candies to earn points.\nAvoid the blades or you will die.\nBeware of falling broccoli sprouts...\nthey will cause you to lose points!\n\nUse the arrow keys and the space bar to control your chef.";
            instructionsLabel.Visible = true;
            backButton.Visible = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //show menu
            titleLabel.Visible = true;
            enterNameLabel.Visible = true;
            nameInput.Visible = true;
            startButton.Visible = true;
            instructionsButton.Visible = true;
            instructionsLabel.Visible = false;
            backButton.Visible = false;
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();

            //hide game
            chefNameLabel.Visible = false;
            scoreLabel.Visible = false;
            menuButton.Visible = false;

            //show menu
            titleLabel.Visible = true;
            enterNameLabel.Visible = true;
            nameInput.Visible = true;
            startButton.Visible = true;
            instructionsButton.Visible = true;
            instructionsLabel.Visible = false;

            //reset
            chefScore = 0;
            chef.X = 10;
            chef.Y = 320;
        }
    }
}
