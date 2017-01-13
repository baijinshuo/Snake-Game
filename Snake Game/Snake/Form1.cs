using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Timers;
using 贪吃蛇;

namespace 贪食蛇
{
    public partial class Form1 : Form
    {
        int a;
        Graphics g ;
        snake s;
        food f;
        int score = 0;
        ArrayList plist;
        SolidBrush br = new SolidBrush(Color .Blue );
        
        
        public Form1()
        {
            InitializeComponent();
        }
        public void clearMe()
        {
            for (int i = 0; i < plist.Count; i++)
            {
                partOfSnake a = (partOfSnake)plist[i];
                Rectangle r = new Rectangle(a.Orign.X, a.Orign.Y, 20, 20);
                g.FillRectangle(Brushes.White , r);
            }
        }
        public void drawMe(Graphics g)
        {
            clearMe();
         
          
            for (int i = 0; i < s.alist.Count; i++)
            {
                partOfSnake a = (partOfSnake)s.alist[i];
                Rectangle r = new Rectangle(a.Orign.X, a.Orign.Y, 20, 20);
                g.FillRectangle(br, r);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {if(timer1 .Enabled ==true)
        {if (e.KeyCode == Keys.Up && s.Way != 1&&s.Way!=3)
            {
                s.Way = 1;
                add();
            }
            if (e.KeyCode == Keys.Left && s.Way != 2 && s.Way != 4)
            {
               s.Way = 2;
               add();
            }
            if (e.KeyCode == Keys.Down && s.Way != 3 && s.Way != 1)     
            {
                s.Way = 3;
                add();
            }
            if (e.KeyCode == Keys.Right && s.Way != 4 && s.Way != 2)
            {
                s.Way = 4;
                add();
            }
            if(e.KeyCode == Keys.ControlKey)
            {
                if (checkBox1.Checked == true)
                    checkBox1.Checked = false;
                else
                    checkBox1.Checked = true;
            }
        }
        }


       

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void button2_Click_1(object sender, EventArgs e)
        {
            score = 0;
            label1.Text = "";
            if (radioButton1.Checked == true)
                timer1.Interval = 50;
            else if (radioButton2.Checked == true)
                timer1.Interval = 100;
            else
            {
                radioButton3.Checked = true;
                timer1.Interval = 200;
            }

            g = pictureBox1.CreateGraphics();
            g.Clear(Color .White );
            s = new snake(2);
            
            f = new food();
            f.createFood(s);
            f.drawMe(g);

            plist = s.copy();
            drawMe(g);
            timer1.Start();
            pictureBox1.Focus();
           
            
           
        }
      
        public void   add()
        {
            
            if (!isdead())
            {  if(!eatFood ())
                { pictureBox1.Focus();
                  plist = s.copy();
                  s.extendsnake();
                  s.contractsnake();
                 drawMe(g);
                }
               }
          
            
        }
        public Boolean eatFood()
        {
            Boolean b = false;
            switch(s.Way )
            {
               case 1:
                    if (s.headpoint.Y - 20 == f.position.Y && s.headpoint.X == f.position.X)
                    {
                        s.extendsnake();
                        f.createFood(s);
                        score +=10;
                        label1.Text = score.ToString(); 
                        f.drawMe(g);

                        b = true;
                    }
                    break;
               case 3:
                    if (s.headpoint.Y + 20 == f.position.Y &&s.headpoint .X ==f.position .X )
                    {
                        s.extendsnake();
                        f.createFood(s);
                        score += 10;
                        label1.Text = score.ToString(); 
                        f.drawMe(g);
                        b = true;
                    }
                    break;
                case 2:
                    if (s.headpoint.X - 20 == f.position.X && s.headpoint.Y == f.position.Y)
                    {
                        s.extendsnake();
                        f.createFood(s);
                        score += 10;
                        label1.Text = score.ToString(); 
                        f.drawMe(g);
                        b = true;
                    }
                    break;
                default:
                    if (s.headpoint.X + 20 == f.position.X && s.headpoint.Y == f.position.Y)
                    {
                        s.extendsnake();
                        f.createFood(s);
                        score += 10;
                        label1.Text = score.ToString(); 
                        f.drawMe(g);
                        b = true;
                    }
                    break;
            }
            return b;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isdead())
                timer1.Enabled = false;
            else
            {
                add();
                if (checkBox1.Checked == true)
                {
                    Pen p = new Pen(Color.Blue);
                    for (a = 0; a <= 600; a += 20)
                    {
                        Point p1 = new Point(a, 0);
                        Point p2 = new Point(a, pictureBox1.Height);
                        Point p3 = new Point(0, a);
                        Point p4 = new Point(pictureBox1.Width, a);
                        g.DrawLine(p, p1, p2);
                        g.DrawLine(p, p3, p4);

                    }
                }
                else
                {
                    Pen p = new Pen(Color.White );
                    for (a = 0; a <= 600; a += 20)
                    {
                        Point p1 = new Point(a, 0);
                        Point p2 = new Point(a, pictureBox1.Height);
                        Point p3 = new Point(0, a);
                        Point p4 = new Point(pictureBox1.Width, a);
                        g.DrawLine(p, p1, p2);
                        g.DrawLine(p, p3, p4);

                    }
                }
            }
           
          
            
        }
        public Boolean isdead()
        {

            if (s.deadsnake())
            {

                timer1.Stop();
                MessageBox.Show("You are dead!");
                return true;
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(this.Form1_KeyDown);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Color c = colorDialog1.Color;
            br = new SolidBrush(c);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

       

       
       
       

     
    }
}
