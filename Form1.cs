using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int xx;
        int yy;
        Panel[,] panels = new Panel[100, 100];
        List<RegionNumber> wpanels = new List<RegionNumber>();
        List<RegionNumber> bpanels = new List<RegionNumber>();//Cherni Oblasti
        private void button1_Click(object sender, EventArgs e)
        {

            Random r = new Random();
            const int sizex = 70;
            const int sizey = 90;

            int incrx = 0;
            int incry = 0;

            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            xx = x;
            yy = y;

            const int startx = 50;
            const int starty = 50;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                    Panel p = new Panel();
                    p.Location = new Point(startx + incrx, starty + incry);
                    p.Size = new Size(sizex, sizey);

                    incrx += (sizex + 20);
                    if (r.Next(1, 3) == 2)
                    {
                        p.BackColor = Color.Black;
                    }
                    else
                    {
                        p.BackColor = Color.White;
                    }

                    this.Controls.Add(p);
                    panels[i, j] = p;
                }
                incry += (sizey + 50); incrx = 0;
            }

            //Namirane na oblasti bqla oblast
            for (int i = 0; i < x - 1; i++)
            {
                for (int j = 0; j < y - 1; j++)
                {
                    if (panels[i, j].Visible == true)
                        if (panels[i, j].BackColor.Equals(Color.White))
                            if (panels[i, j].BackColor.Equals(panels[i, j + 1].BackColor) && (panels[i, j].BackColor.Equals(panels[i + 1, j].BackColor) && (panels[i, j].BackColor.Equals(panels[i + 1, j + 1].BackColor))))
                            {
                                RegionNumber s5 = new RegionNumber(i, j);
                                RegionNumber s1 = new RegionNumber(i + 1, j);
                                RegionNumber s2 = new RegionNumber(i, j + 1);
                                RegionNumber s3 = new RegionNumber(i + 1, j + 1);
                                wpanels.Add(s5);
                                wpanels.Add(s1);
                                wpanels.Add(s2);
                                wpanels.Add(s3);
                                panels[i, j].Visible = false;
                                panels[i, j + 1].Visible = false;
                                panels[i + 1, j].Visible = false;
                                panels[i + 1, j + 1].Visible = false;




                            }


                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    panels[i, j].Visible = true;
                }
            }
            for (int i = 0; i < x - 1; i++)//Namirane na cherni paneli

            {
                for (int j = 0; j < y - 1; j++)
                {
                    if (panels[i, j].Visible == true)
                        if (panels[i, j].BackColor.Equals(Color.Black))
                            if (panels[i, j].BackColor.Equals(panels[i, j + 1].BackColor) && (panels[i, j].BackColor.Equals(panels[i + 1, j].BackColor) && (panels[i, j].BackColor.Equals(panels[i + 1, j + 1].BackColor))))
                            {
                                RegionNumber s5 = new RegionNumber(i, j);
                                RegionNumber s1 = new RegionNumber(i + 1, j);
                                RegionNumber s2 = new RegionNumber(i, j + 1);
                                RegionNumber s3 = new RegionNumber(i + 1, j + 1);
                                bpanels.Add(s5);
                                bpanels.Add(s1);
                                bpanels.Add(s2);
                                bpanels.Add(s3);
                                panels[i, j].Visible = false;
                                panels[i, j + 1].Visible = false;
                                panels[i + 1, j].Visible = false;
                                panels[i + 1, j + 1].Visible = false;



                            }


                }
            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    panels[i, j].Visible = true;
                }
            }
            foreach (RegionNumber p in bpanels)
            {
                MessageBox.Show(Convert.ToString(p.getX()) + ":" + Convert.ToString(p.getY()));
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color r = Color.Red;

            int num = Convert.ToInt32(textBox3.Text);
            int curnum = 0;
            for (int i = 0; i < xx; i++)
            {
                for (int j = 0; j < yy; j++)
                {
                    curnum++;
                    if (curnum == num)
                    {
                        r = panels[i, j].BackColor;
                        break;

                    }
                }
            }
            if (r.Equals(Color.White))
            {
                String s = Convert.ToString(wpanels.Count / 4);
                MessageBox.Show("White Regions" + s);
            }
            if (r.Equals(Color.Black))
            {
                String s = Convert.ToString(bpanels.Count / 4);
                MessageBox.Show("Black Regions:" + s);

            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            Color r = Color.Red;

            int num = Convert.ToInt32(textBox3.Text);
            int curnum = 0;
            for (int i = 0; i < xx; i++)
            {
                for (int j = 0; j < yy; j++)
                {
                    curnum++;
                    if (curnum == num)
                    {
                        r = panels[i, j].BackColor;
                        break;

                    }
                }
            }
            if (r.Equals(Color.White))
            {
                String s = Convert.ToString(bpanels.Count / 4);
                MessageBox.Show("Black Regions:" + s);

            }
            if (r.Equals(Color.Black))
            {
                String s = Convert.ToString(wpanels.Count / 4);
                MessageBox.Show("White Regions" + s);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Color r = Color.Red;

            int num = Convert.ToInt32(textBox3.Text);
            int curnum = 0;
            for (int i = 0; i < xx; i++)
            {
                for (int j = 0; j < yy; j++)
                {
                    curnum++;
                    if (curnum == num)
                    {
                        r = panels[i, j].BackColor;
                        break;

                    }
                }
            }
            if (r.Equals(Color.White))
            {
                if ((wpanels.Count / 4) - 1 < 0)
                {
                    String s = Convert.ToString((wpanels.Count / 4) - 1);
                    MessageBox.Show("White Regions" + s);
                }
                else
                {
                    MessageBox.Show("0");
                }
            }
            if (r.Equals(Color.Black))
            {
                if ((wpanels.Count / 4) - 1 < 0)
                {
                    String s = Convert.ToString((bpanels.Count / 4) - 1);
                    MessageBox.Show("Black Regions:" + s);
                }
                else
                {
                    MessageBox.Show("0");
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox3.Text)-1;
            int ii = 0;
            int jj = 0;
            while (num > 0)
            {
                if (num >= xx)
                {
                    ii++;
                    num -= xx;
                    jj = num;
                }
                else
                {
                    jj = num;
                    num = -1;
                }

            }

             //MessageBox.Show(Convert.ToString(ii)+":"+Convert.ToString(jj));
            Boolean flag = false;
            foreach (RegionNumber r in bpanels)
            {
                if (r.getX() == ii && r.getY() == jj)
                {
                    flag = true;
                }
            }
            foreach (RegionNumber r in wpanels)
            {
                if (r.getX() == ii && r.getY() == jj)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                MessageBox.Show("4");
            }
            else
            {
                MessageBox.Show("1");
            }
        }
    }

}
