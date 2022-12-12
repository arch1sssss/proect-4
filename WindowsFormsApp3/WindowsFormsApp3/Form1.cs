using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
 PictureBox[] pb = new PictureBox[16];
        Image cardBack = Image.FromFile(@"C:\Users\28-1.CLP.000\Desktop\asd\resources\вопрос.jpg");
        Image[] img_lvl_1 = new Image[16];
        PictureBox activePB = null;
        public Form1()
        {
            InitializeComponent();
            pb[0] = pictureBox1;
            pb[1] = pictureBox2;
            pb[2] = pictureBox3;
            pb[3] = pictureBox4;
            pb[4] = pictureBox5;
            pb[5] = pictureBox6;
            pb[6] = pictureBox7;
            pb[7] = pictureBox8;
            pb[8] = pictureBox9;
            pb[9] = pictureBox10;
            pb[10] = pictureBox11;
            pb[11] = pictureBox12;
            pb[12] = pictureBox13;
            pb[13] = pictureBox14;
            pb[14] = pictureBox15;
            pb[15] = pictureBox16;
            img_lvl_1[0] = img_lvl_1[8] = Image.FromFile(@"C:\Users\28-1.CLP.000\Desktop\asd\resources\lvl1\p1.jpg");
            img_lvl_1[1] = img_lvl_1[9] = Image.FromFile(@"C:\Users\28-1.CLP.000\Desktop\asd\resources\lvl1\p2.jpg");
            img_lvl_1[2] = img_lvl_1[10] = Image.FromFile(@"C:\Users\28-1.CLP.000\Desktop\asd\resources\lvl1\p3.jpg");
            img_lvl_1[3] = img_lvl_1[11] = Image.FromFile(@"C:\Users\28-1.CLP.000\Desktop\asd\resources\lvl1\p4.jpg");
            img_lvl_1[4] = img_lvl_1[12] = Image.FromFile(@"C:\Users\28-1.CLP.000\Desktop\asd\resources\lvl1\p5.jpg");
            img_lvl_1[5] = img_lvl_1[13] = Image.FromFile(@"C:\Users\28-1.CLP.000\Desktop\asd\resources\lvl1\p6.jpg");
            img_lvl_1[6] = img_lvl_1[14] = Image.FromFile(@"C:\Users\28-1.CLP.000\Desktop\asd\resources\lvl1\p7.jpg");
            img_lvl_1[7] = img_lvl_1[15] = Image.FromFile(@"C:\Users\28-1.CLP.000\Desktop\asd\resources\lvl1\p8.jpg");

            for (int i = 0; i < 16; i++)
            {
                pb[i].Click += pbClick;
                pb[i].Enabled = true;
            }
        }

       private async void pbClick(object sender,EventArgs e)
        {
            PictureBox pbox = sender as PictureBox;
            pbox.BackgroundImage = pbox.InitialImage;
            if (activePB != null)
            {
                if (activePB.BackgroundImage == pbox.BackgroundImage && activePB != pbox)
                {
                    activePB.Enabled = false;
                    pbox.Enabled = false;
                    if (checkwin(pb) == true)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            pb[i].Visible = false;
                        }
                        label1.Visible = true;
                        label1.Text = "Вы победили";
                        button1.Visible = true;
                        label2.Visible = false;
                        timer1.Stop();
                    }
                }
                else
                {
                    Form1.ActiveForm.Enabled = false;
                    await Task.Delay(500);
                    Form1.ActiveForm.Enabled = true;
                    activePB.InitialImage = activePB.BackgroundImage;
                    activePB.BackgroundImage = cardBack;
                    pbox.InitialImage = pbox.BackgroundImage;
                    pbox.BackgroundImage = cardBack;
                }
                activePB = null;

            }
            else
            {
                activePB = pbox;
            }
        }

        private void imgShuffle(Image[] imgArr)
        {
            Random random = new Random();
            for (int i = imgArr.Length-1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = imgArr[j];
                imgArr[j] = imgArr[i];
                imgArr[i] = temp;
            }
        }
        private bool checkwin(PictureBox[] pbArr)
        {
            bool checkwin = true;
            for(int i = 0; i < pbArr.Length; i++)
            {
                if (pbArr[i].Enabled == true)
                    checkwin = false;
            }
            return checkwin;
        }
        int i;
        int tk;
        string c;
        private void button1_Click(object sender, EventArgs e)
        {
            i = 78;
            c = "01:10";
            label2.Visible = true;
            label2.Text = c;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
            label1.Visible = false;
            button1.Visible = false;
            imgShuffle(img_lvl_1);
            for (int i = 0; i < 16; i++)
            {
                pb[i].Visible = true;
                pb[i].Enabled = true;
                pb[i].BackgroundImage = cardBack;
                pb[i].BackgroundImageLayout = ImageLayout.Stretch;
                pb[i].InitialImage = img_lvl_1[i];
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 16; i++)
            {
                pb[i].Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            tk = --i;
            TimeSpan span = TimeSpan.FromMinutes(tk);
            string label = span.ToString(@"hh\:mm");
            label2.Text = label.ToString();
            if (i< 0)
                {
                timer1.Stop();
                for (int i = 0; i < 16; i++)
                {
                    pb[i].Visible = false;

                }
                label1.Visible = true;
                label1.Text = "вы проиграли";
                button1.Visible = true;
                label2.Visible = false;
                }
        }
    }
}
