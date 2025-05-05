using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chick
{
    class chicken
    {
        public int x, y;
        
        public Bitmap im;

    }

    class egg
    {
        public int x, y;
        
        public Bitmap im;
    }

    class nest
    {
        public int x, y;

        public List<egg> Lnegg = new List<egg>();

        public Bitmap im;
    }

    public partial class Form1 : Form
    {
        Bitmap off;
        List<chicken> Lchicken = new List<chicken>();
        List<egg> Legg = new List<egg>();
        List<nest> Lnest = new List<nest>();

        int i=0 ;
        bool isDrag = false;
        int WhichNest = -1;
        int xold, yold;
        int F = 0;
        int x1, y1, x2, y2 ;
        int XS = 15;
        int XS2 = 25;
        int XS3 = 25;
        int XS4 = 400;
        int XS5 = 300;



        public Form1()
        {
            this.Load += new EventHandler (Form1_Load);
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += new KeyEventHandler (Form1_KeyDown);
            this.Paint += new PaintEventHandler (Form1_Paint);
            this.MouseMove += new MouseEventHandler (Form1_MouseMove);
            this.MouseUp += new MouseEventHandler (Form1_MouseUp);
            this.MouseDown += new MouseEventHandler (Form1_MouseDown);

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                WhichNest = HitWindow(e.X, e.Y);

                if (WhichNest != -1)
                {
                    isDrag = true;
                    xold = e.X;
                    yold = e.Y;
                   
                }

            }
            
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            WhichNest = -1;
            xold = -1;
            yold = -1;
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDrag)
            {
                int dx = e.X - xold;
                int dy = e.Y - yold;


                Lnest[WhichNest].x += dx;
                Lnest[WhichNest].y += dy;

                for (int i = 0; i < Lnest[WhichNest].Lnegg.Count; i++) //3shan n7ark el nest bl eggs 
                {
                    Lnest[WhichNest].Lnegg[i].x += dx;
                    Lnest[WhichNest].Lnegg[i].y += dy;
                }
                xold = e.X;
                yold = e.Y;
            }
            DrawDubb(this.CreateGraphics());
        }
        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                Lchicken[0].x += 10;
     
                if (Lchicken[0].x == 1000)
                {

                    Lchicken[0].x -= 10;
                    
                }
                DrawDubb(this.CreateGraphics());

            }

            if(e.KeyCode==Keys.Left)
            {
                Lchicken[0].x -= 10;
                
                //if (Lchicken[0].x == 100)
                //{

                //    Lchicken[0].x += 10;
                   
                //}
                DrawDubb(this.CreateGraphics());
            }

            if (e.KeyCode == Keys.Space)
            {
                
                if(Lchicken[0].x==Lnest[0].x || Lchicken[0].x + 25 > Lnest[0].x && Lchicken[0].x < Lnest[0].x + 50) 
                {
                    F = 1;
                    CreateEggs();
                }

                if (Lchicken[0].x == Lnest[1].x || Lchicken[0].x + 25 > Lnest[1].x && Lchicken[0].x < Lnest[1].x + 50) 
                {
                    F = 2;
                    CreateEggs();
                }

                if (Lchicken[0].x == Lnest[2].x || Lchicken[0].x + 25 > Lnest[2].x && Lchicken[0].x < Lnest[2].x + 50) 
                {
                    F = 3;
                    CreateEggs();
                }

                //egg pne = new egg();
                //pne.x = XS4;
                //pne.y = XS5 ;
                //pne.im = new Bitmap("e1.bmp");
                ////XS += pne.im.Width;
                //pne.im.MakeTransparent(pne.im.GetPixel(0, 0));



                DrawDubb(this.CreateGraphics());

            }

        }
            

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            CreateChicken();
            CreateNests();
            DrawDubb(this.CreateGraphics());
        }


        void CreateChicken()
        {
            chicken pnc = new chicken();
            pnc.im = new Bitmap("c.bmp");
            pnc.im.MakeTransparent(pnc.im.GetPixel(0, 0));
            pnc.x = 500;
            pnc.y = 20;
            Lchicken.Add(pnc);
        }


        void CreateNests()
        {

            nest pnn = new nest();
            pnn.im = new Bitmap("n.bmp");
            pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
            pnn.x = 500;
            pnn.y = 500;
            Lnest.Add(pnn); //Middle nest

            nest pnn1 = new nest();
            pnn1.im = new Bitmap("n.bmp");
            pnn1.im.MakeTransparent(pnn1.im.GetPixel(0, 0));
            pnn1.x = 900;
            pnn1.y = 500;
            Lnest.Add(pnn1); //Nest on the right side


            nest pnn2 = new nest();
            pnn2.im = new Bitmap("n.bmp");
            pnn2.im.MakeTransparent(pnn2.im.GetPixel(0, 0));
            pnn2.x = 100;
            pnn2.y = 500;
            Lnest.Add(pnn2); // Nest on the left side

        }
        
        void CreateEggs()
        {

            if (F == 1)
            {
                
                for(int i=0; i<3; i++)
                {
                    egg pne = new egg();
                    pne.x = Lchicken[0].x + XS;
                    pne.y = Lnest[0].y + 20;
                    pne.im = new Bitmap("e1.bmp");
                     XS+= pne.im.Width;
                    pne.im.MakeTransparent(pne.im.GetPixel(0, 0));
                    Legg.Add(pne);
                    Lnest[0].Lnegg.Add(pne);
                }

            }

            if (F == 2)
            {

                for (int i = 0; i < 3; i++)
                {
                    egg pne1 = new egg();
                    pne1.x = Lchicken[0].x + XS2;
                    pne1.y = Lnest[0].y + 20;
                    pne1.im = new Bitmap("e1.bmp");
                    XS2 += pne1.im.Width;
                    pne1.im.MakeTransparent(pne1.im.GetPixel(0, 0));
                    Legg.Add(pne1);
                    Lnest[1].Lnegg.Add(pne1);
                }

            }

            if (F == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    egg pne2 = new egg();
                    pne2.x = Lchicken[0].x + XS3;
                    pne2.y = Lnest[0].y + 20;
                    pne2.im = new Bitmap("e1.bmp");
                    XS3 += pne2.im.Width;
                    pne2.im.MakeTransparent(pne2.im.GetPixel(0, 0));
                    Legg.Add(pne2);
                    Lnest[2].Lnegg.Add(pne2);
                }

            }
        }


        void DrawScene2(Graphics g2)
        {
           
            g2.Clear(Color.Black);

            for (int i = 0; i < Lchicken.Count; i++)
            {
                g2.DrawImage(Lchicken[i].im, Lchicken[i].x, Lchicken[i].y);
            }

            

            for (int i = 0; i < Lnest.Count; i++)
            {
                g2.DrawImage(Lnest[i].im, Lnest[i].x, Lnest[i].y);

                for (int j = 0; j < Lnest[i].Lnegg.Count; j++)
                {
                    g2.DrawImage(Lnest[i].Lnegg[j].im, Lnest[i].Lnegg[j].x, Lnest[i].Lnegg[j].y);
                }
            }


        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene2(g2);
            g.DrawImage(off, 0, 0);
        }

        int HitWindow(int PX, int PY)
        {
            for (i = 0; i < Lnest.Count; i++)
            {
                x1 = Lnest[i].x;
                x2 = Lnest[i].x + Lnest[i].im.Width;
                y1 = Lnest[i].y;
                y2 = Lnest[i].y + Lnest[i].im.Height;


                if (PX >= x1 && PX <= x2 && PY >= y1 && PY<=y2 )
                {
                    return i;                //It will return the selected window from the list
                }
            }

            return -1;
        }

    }
}
