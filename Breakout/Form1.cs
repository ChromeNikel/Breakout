using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class Form1 : Form
    {
        int pointsCount;
        Collection<PictureBox> pb;
        Game game;
        int direction = 0;
        int speedController = 10;
        int speedBoll = 6;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            pb = new Collection<PictureBox>();
            game = new Game();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBoxController.Left = panel1.Width / 2 - pictureBoxController.Width / 2;
            pictureBoxBoll.Left = panel1.Width / 2 - pictureBoxBoll.Width / 2;
            pictureBoxBoll.BringToFront();
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                {
                    pb.Add((PictureBox)tableLayoutPanel1.GetControlFromPosition(i, j));
                }
            }            
        }
        
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (pictureBoxController.Left > panel1.Left)
            {               
                if (e.KeyChar == Convert.ToChar(Keys.A) || e.KeyChar == Convert.ToChar(Keys.A.ToString().ToLower()))
                {
                    if (timer1.Enabled == false)
                    {
                        pictureBoxBoll.Left = pictureBoxBoll.Left - speedController;
                    }
                    pictureBoxController.Left = pictureBoxController.Left - speedController;
                }
            } 
               if(pictureBoxController.Right < panel1.Right )
            {               
                if (e.KeyChar == Convert.ToChar(Keys.D) || e.KeyChar == Convert.ToChar(Keys.D.ToString().ToLower()))
                {
                    if (timer1.Enabled == false)
                    {
                        pictureBoxBoll.Left = pictureBoxBoll.Left + speedController;
                    }
                    pictureBoxController.Left = pictureBoxController.Left + speedController;
                }
            }
        }

        private void pictureBoxBoll_Move(object sender, EventArgs e)
        {         
            int LEFT = pictureBoxBoll.Left;
            int TOP = pictureBoxBoll.Top;
            int BOTTOM = pictureBoxBoll.Top + pictureBoxBoll.Height;
            int RIGHT = pictureBoxBoll.Left + pictureBoxBoll.Width;
            
            foreach (var onepb in pb)
            {
                if (onepb.Visible == true)
                {                  
                    if (BOTTOM >= onepb.Top && ((LEFT > onepb.Left && LEFT < onepb.Right) || (RIGHT < onepb.Right && RIGHT > onepb.Left)) &&
                                      (BOTTOM < onepb.Bottom))
                    {
                        
                        if (direction == 2)
                        {
                            direction = 1;
                        }
                        else if (direction == 3)
                        {
                            direction = 0;
                        }
                        direction = 1;                        
                        pointsCount++;
                        if (pointsCount % 10 == 0)
                        {                           
                            speedBoll++;
                        }
                        
                        Sound.spPick.Play();
                        onepb.Visible = false;
                       
                    } else
                    if (TOP <= onepb.Bottom && ((LEFT > onepb.Left && LEFT < onepb.Right) || (RIGHT < onepb.Right && RIGHT > onepb.Left)) &&
                        TOP > onepb.Top)
                    {
                      
                        if (direction == 0)
                        {
                            direction = 3;
                        }
                        else
                        {
                            if (direction == 1)
                            {
                                direction = 2;
                            }
                        }                
                        pointsCount++;
                        if (pointsCount % 10 == 0)
                        {
                            speedBoll++;
                        }

                        Sound.spPick.Play();
                        onepb.Visible = false;
                       
                    } else
                    if (LEFT <= onepb.Right && ((TOP > onepb.Top && TOP < onepb.Bottom) || (BOTTOM > onepb.Top && BOTTOM < onepb.Bottom)) &&
                        LEFT > onepb.Left)
                    {
                        
                        if (direction == 2)
                        {
                            direction = 3;
                        }
                        else if (direction == 1)
                        {
                            direction = 0;
                        }
                        pointsCount++;
                        if (pointsCount % 10 == 0)
                        {
                            speedBoll++;
                        }

                        Sound.spPick.Play();
                        onepb.Visible = false;
                      
                    } else
                    if (RIGHT >= onepb.Left && ((TOP > onepb.Top && TOP < onepb.Bottom) || (BOTTOM > onepb.Top && BOTTOM < onepb.Bottom)) &&
                        RIGHT < onepb.Right)
                    {
                        if (direction == 3)
                        {
                            direction = 2;
                        }
                        else if(direction == 0)
                        {
                            direction = 1;
                        }
                        pointsCount++;
                        if (pointsCount % 10 == 0)
                        {
                            speedBoll++;
                        }
                        Sound.spPick.Play();
                        onepb.Visible = false;
                      
                    }
                }
                linkLabel1.Text = "Очки: " + pointsCount.ToString();
            }
            if (RIGHT >= panel1.Right)
            {
                if (direction == 3)
                {
                    direction = 2;
                }
                else if (direction == 0)
                {
                    direction = 1;
                }
            }
            if (TOP <= panel1.Top)
            {
                if (direction == 0)
                {
                    direction = 3;
                }
                else if (direction == 1)
                {
                    direction = 2;
                }
            }
            if (LEFT <= panel1.Left)
            {
                if (direction == 2)
                {
                    direction = 3;
                }
                else if (direction == 1)
                {
                    direction = 0;
                }
            }
            if (BOTTOM >= pictureBoxController.Top && ((LEFT < pictureBoxController.Right && LEFT > pictureBoxController.Left) ||
                (RIGHT > pictureBoxController.Left && RIGHT < pictureBoxController.Right)))
            {
                if (direction == 3)
                {
                    direction = 0;
                }
                else if (direction == 2)
                {
                    direction = 1;
                }
                Sound.spMove.Play();
                pictureBoxBoll.Top = panel1.Top + panel1.Height - 110;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
           
            speedController = 10;
            pointsCount = 0;    
            ///ремонтируем поле
            //pictureBoxController.Left = panel1.Width / 2 - pictureBoxController.Width / 2;
            //pictureBoxBoll.Left = panel1.Width / 2 - pictureBoxBoll.Width / 2;
            //pictureBoxBoll.Top = panel1.Top + panel1.Height - 110;
            foreach (var onepb in pb)
            {
                onepb.Visible = true;
            }
            ///
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            pictureBoxBoll.Left = game.Move(pictureBoxBoll.Left, pictureBoxBoll.Top, 45, direction, speedBoll).X;
            pictureBoxBoll.Top = game.Move(pictureBoxBoll.Left, pictureBoxBoll.Top, 45, direction, speedBoll).Y;
           
            if (pictureBoxBoll.Bottom > pictureBoxController.Bottom && ((pictureBoxBoll.Left < pictureBoxController.Left) ||
                (pictureBoxBoll.Right > pictureBoxController.Right)))
            {
                Sound.spFail.Play();
                timer1.Enabled = false;
                MessageBox.Show("Вы проиграли!\nВаш результат: " + pointsCount, "Печалька :-(", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pictureBoxController.Left = panel1.Width / 2 - pictureBoxController.Width / 2;
                pictureBoxBoll.Left = panel1.Width / 2 - pictureBoxBoll.Width / 2;
                pictureBoxBoll.Top = panel1.Top + panel1.Height - 110;
            }
            bool emptyString = true;
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                var x = tableLayoutPanel1.GetControlFromPosition(i, 4);
                if (x.Visible == true)
                {
                    emptyString = false;
                }
            }
            if (emptyString == true)
            {
                bool[] time0 = new bool[tableLayoutPanel1.ColumnCount];
                bool[] time1 = new bool[tableLayoutPanel1.ColumnCount];

                for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                {
                    for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                    {
                        var x = tableLayoutPanel1.GetControlFromPosition(j, i);
                        if (i == 0)
                        {
                            time0[j] = x.Visible;
                            x.Visible = true;
                        }
                        time1[j] = x.Visible;
                        x.Visible = time0[j];
                        time0[j] = time1[j];
                    }
                }
            }
        }

        
    }
}
