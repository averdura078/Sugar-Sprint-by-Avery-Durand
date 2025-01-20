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
        List<string> candyColours = new List<string>();
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush goldYellowBrush = new SolidBrush(Color.Gold);
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush purpleBrush = new SolidBrush(Color.DarkViolet);

        //grass
        List<Rectangle> grass = new List<Rectangle>();
        SolidBrush grassBrush = new SolidBrush(Color.MediumSeaGreen);

        //keys
        bool leftPressed = false;
        bool rightPressed = false;
        bool jumpPressed = false;
        bool escPressed = false;

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
                case Keys.Escape:
                    escPressed = false;
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
                case Keys.Escape:
                    escPressed = true;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(yellowBrush, chef);

            e.Graphics.FillRectangle(groundBrush, ground);

            //draw blades
            for (int i = 0; i < blades.Count; i++)
            {
                e.Graphics.FillRectangle(grayBrush, blades[i]);
            }

            //draw candies
            for (int i = 0; i < candies.Count; i++)
            {
                if (candyColours[i] == "red")
                {
                    e.Graphics.FillEllipse(redBrush, candies[i]);
                }
                else if (candyColours[i] == "orange")
                {
                    e.Graphics.FillEllipse(orangeBrush, candies[i]);
                }
                else if (candyColours[i] == "light yellow")
                {
                    e.Graphics.FillEllipse(goldYellowBrush, candies[i]);
                }
                else if (candyColours[i] == "blue")
                {
                    e.Graphics.FillEllipse(blueBrush, candies[i]);
                }
                else if (candyColours[i] == "purple")
                {
                    e.Graphics.FillEllipse(purpleBrush, candies[i]);
                }
            }

            //draw broccoli

            //draw grass
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (escPressed == true)
            {
                //show menu
                ShowMenu();
            }

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
                if (jumpUpOrDown <= 14)
                {
                    //up
                    chef.Y -= chefSpeed;
                }
                if (jumpUpOrDown > 14)
                {
                    //down
                    chef.Y += chefSpeed;
                }
                if (jumpUpOrDown == 28)
                {
                    jumpUpOrDown = 0;
                    jumpPressed = false;
                }

            }

            //create blades
            //random percent occurrance
            int randBladeOccurance = randGen.Next(1, 101);
            //random height
            if (randBladeOccurance < 2)
            {
                //random height
                int sizeY = randGen.Next(50, 100);

                Rectangle newBlade = new Rectangle(this.Width, 350 - sizeY, 50, sizeY);

                blades.Add(newBlade);
            }

            //move blades
            for (int i = 0; i < blades.Count; i++)
            {
                int x = blades[i].X - 6;
                blades[i] = new Rectangle(x, blades[i].Y, blades[i].Width, blades[i].Height);
            }

            //create candies
            //random percent occurrance
            int randCandyOccurance = randGen.Next(1, 101);
            int randColour = randGen.Next(1, 101);
            if (randCandyOccurance < 3)
                if (randColour < 20)
                {
                    Rectangle newCandy = new Rectangle(this.Width, 350 - 40, 40, 40);

                    candies.Add(newCandy);
                    candyColours.Add("red");
                }
                else if (randColour < 40)
                {
                    Rectangle newCandy = new Rectangle(this.Width, 350 - 40, 40, 40);

                    candies.Add(newCandy);
                    candyColours.Add("orange");
                }
                else if (randColour < 60)
                {
                    Rectangle newCandy = new Rectangle(this.Width, 350 - 40, 40, 40);

                    candies.Add(newCandy);
                    candyColours.Add("light yellow");
                }
                else if (randColour < 80)
                {
                    Rectangle newCandy = new Rectangle(this.Width, 350 - 40, 40, 40);

                    candies.Add(newCandy);
                    candyColours.Add("blue");
                }
                else if (randColour < 100)
                {
                    Rectangle newCandy = new Rectangle(this.Width, 350 - 40, 40, 40);

                    candies.Add(newCandy);
                    candyColours.Add("purple");
                }

            //move candies
            for (int i = 0; i < candies.Count; i++)
            {
                int x = candies[i].X - 6;
                candies[i] = new Rectangle(x, candies[i].Y, candies[i].Width, candies[i].Height);
            }

            //create broccolis

            //move broccolis

            //create grass

            //move grass

            //check for collision with blades

            //check for collision with broccolis

            //check for collision with candies

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
            instructionsLabel.Text = "Welcome to Sugar Sprint, chef!\n\nCollect the rainbow candies to earn points.\nAvoid the blades or you will die.\nBeware of falling broccoli sprouts...\nthey will cause you to lose points!\n\nUse the arrow keys to move and space to jump.\nClick Esc to end game.";
            instructionsLabel.Visible = true;
            backButton.Visible = true;
            backButton.Enabled = true;
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

        private void ShowMenu()
        {
            gameTimer.Stop();

            //hide game
            chefNameLabel.Visible = false;
            scoreLabel.Visible = false;

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
