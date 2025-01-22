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
        SolidBrush groundBrush = new SolidBrush(Color.SeaGreen);

        //player
        Rectangle chef = new Rectangle(10, 320, 30, 30);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Pen blackPen = new Pen(Color.Black, 3);
        int chefSpeed = 9;
        int chefJumpSpeed = 16;
        int chefScore = 0;
        int highScore = 0;
        int jumpUpOrDown = 0;

        //blades
        List<Rectangle> blades = new List<Rectangle>();
        SolidBrush grayBrush = new SolidBrush(Color.Gray);
        int creationCounter = 0;

        //falling obstacles
        List<Rectangle> broccolis = new List<Rectangle>();
        List<int> broccoliSpeeds = new List<int>();
        SolidBrush lightGreenBrush = new SolidBrush(Color.LightGreen);
        SolidBrush greenBrush = new SolidBrush(Color.Green);

        //candies
        List<Rectangle> candies = new List<Rectangle>();
        List<string> candyColours = new List<string>();
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush goldYellowBrush = new SolidBrush(Color.Gold);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
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
            //draw chef
            e.Graphics.FillRectangle(yellowBrush, chef);
            e.Graphics.FillRectangle(whiteBrush, chef.X - 5, chef.Y - 5, chef.Width + 10, 15);
            e.Graphics.FillEllipse(whiteBrush, chef.X - 10, chef.Y - 18, 20, 20);
            e.Graphics.FillEllipse(whiteBrush, chef.X + chef.Width - 10, chef.Y - 18, 20, 20);
            e.Graphics.FillEllipse(whiteBrush, chef.X + 5, chef.Y - 26, 20, 25);
            e.Graphics.FillEllipse(blackBrush, chef.X + 4, chef.Y + 11, 5, 5);
            e.Graphics.FillEllipse(blackBrush, chef.X + chef.Width - 4, chef.Y + 11, 5, 5);
            e.Graphics.DrawArc(blackPen, chef.X + 4, chef.Y, 25, 25, 400, 100);

            //draw broccoli
            for (int i = 0; i < broccolis.Count; i++)
            {
                e.Graphics.FillRectangle(lightGreenBrush, broccolis[i]);
                e.Graphics.FillEllipse(greenBrush, broccolis[i].X - 10, broccolis[i].Y - 14, 20, 20);
                e.Graphics.FillEllipse(greenBrush, broccolis[i].X + broccolis[i].Width - 10, broccolis[i].Y - 14, 20, 20);
                e.Graphics.FillEllipse(greenBrush, broccolis[i].X + 5, broccolis[i].Y - 22, 20, 25);
                e.Graphics.FillEllipse(greenBrush, broccolis[i].X - 3, broccolis[i].Y - 5, 20, 20);
                e.Graphics.FillEllipse(greenBrush, broccolis[i].X + broccolis[i].Width - 15, broccolis[i].Y - 5, 20, 20);
            }

            //draw ground
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

            //draw grass
            for (int i = 0; i < grass.Count; i++)
            {
                e.Graphics.FillRectangle(grassBrush, grass[i]);
                e.Graphics.FillRectangle(grassBrush, grass[i].X + 5, grass[i].Y + 3, grass[i].Width, grass[i].Height);
                e.Graphics.FillRectangle(grassBrush, grass[i].X - 5, grass[i].Y + 3, grass[i].Width, grass[i].Height);
                e.Graphics.FillRectangle(grassBrush, grass[i].X + 10, grass[i].Y - 3, grass[i].Width, grass[i].Height - 3);
                e.Graphics.FillRectangle(grassBrush, grass[i].X - 10, grass[i].Y - 3, grass[i].Width, grass[i].Height - 3);
            }
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
                if (jumpUpOrDown <= 12)
                {
                    //up
                    chef.Y -= chefJumpSpeed;
                    chefJumpSpeed--;
                }
                if (jumpUpOrDown > 12)
                {
                    //down
                    chef.Y += chefJumpSpeed;
                    chefJumpSpeed++;
                }
                if (jumpUpOrDown == 25)
                {
                    jumpUpOrDown = 0;
                    jumpPressed = false;
                    chefJumpSpeed = 16;
                    chef.Y = 320;
                }

            }

            //create blades
            //random percent occurrance
            //int randBladeOccurance = randGen.Next(1, 101);
            //if (randBladeOccurance < 2)
            //{
            //    //random height
            //    int sizeY = randGen.Next(50, 100);

            //    Rectangle newBlade = new Rectangle(this.Width, 350 - sizeY, 50, sizeY);

            //    blades.Add(newBlade);
            //}

            //random creation interval
            creationCounter--;
            if (creationCounter == 0)
            {
                //random height
                int sizeY = randGen.Next(50, 100);

                Rectangle newBlade = new Rectangle(this.Width, 350 - sizeY, 50, sizeY);

                blades.Add(newBlade);

                creationCounter = randGen.Next(50, 100);
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
            //random percent occurrance
            int randBroccoliOccurance = randGen.Next(1, 101);
            if (randBroccoliOccurance < 3)
            {
                //random height
                int sizeY = randGen.Next(30, 60);

                //random x position
                int x = randGen.Next(0, this.Width);

                //random speed
                int brocSpeed = randGen.Next(3, 11);
                broccoliSpeeds.Add(brocSpeed);

                Rectangle newBroccoli = new Rectangle(x, 0, 30, sizeY);

                broccolis.Add(newBroccoli);
            }

            //move broccolis
            for (int i = 0; i < broccolis.Count; i++)
            {
                int y = broccolis[i].Y + broccoliSpeeds[i];
                broccolis[i] = new Rectangle(broccolis[i].X, y, broccolis[i].Width, broccolis[i].Height);
            }

            //create grass
            //random percent occurrance
            int randGrassOccurance = randGen.Next(1, 101);
            if (randGrassOccurance < 95)
            {
                //random height
                int sizeY = randGen.Next(5, 20);

                //random y position
                int y = randGen.Next(this.Height - 55, this.Height);

                Rectangle newGrass = new Rectangle(this.Width, y, 3, sizeY);

                grass.Add(newGrass);
            }

            //move grass
            for (int i = 0; i < grass.Count; i++)
            {
                int x = grass[i].X - 6;
                grass[i] = new Rectangle(x, grass[i].Y, grass[i].Width, grass[i].Height);
            }

            //remove everything once offscreen
            for (int i = 0; i < blades.Count; i++)
            {
                if (blades[i].X < 0 - blades[i].Width)
                {
                    blades.RemoveAt(i);
                }
            }
            for (int i = 0; i < candies.Count; i++)
            {
                if (candies[i].X < 0 - candies[i].Width)
                {
                    candies.RemoveAt(i);
                    candyColours.RemoveAt(i);
                }
            }
            for (int i = 0; i < broccolis.Count; i++)
            {
                if (broccolis[i].X > this.Height)
                {
                    broccolis.RemoveAt(i);
                    broccoliSpeeds.RemoveAt(i);
                }
            }

            //check for collision with blades
            for (int i = 0; i < blades.Count; i++)
            {
                if (chef.IntersectsWith(blades[i]))
                {
                    gameTimer.Stop();
                }
            }

            //check for collision with broccolis
            for (int i = 0; i < broccolis.Count; i++)
            {
                if (chef.IntersectsWith(broccolis[i]))
                {
                    chefScore--;
                    broccolis.RemoveAt(i);
                }
            }

            //check for collision with candies
            for (int i = 0; i < candies.Count; i++)
            {
                if (chef.IntersectsWith(candies[i]))
                {
                    chefScore++;
                    candies.RemoveAt(i);
                    candyColours.RemoveAt(i);
                }
            }


            //refresh score
            scoreLabel.Text = $"Score: {chefScore}  High Score: {highScore}";
            if (chefScore > highScore)
            {
                highScore = chefScore;
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
