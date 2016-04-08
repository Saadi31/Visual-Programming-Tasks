using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Watermark
{
    public partial class Form2 : Form
    {
        String ChoosedFile;
        public Form2()
        {
            InitializeComponent();
        }


        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
              //  String Choosedfile;
                dlg.Title = "Open Image";
                dlg.Filter = "All Images (*.jpeg , *.jpg , *.bmp , *.png)| *.jpeg;*.jpg;*.bmp;*.png| JPEG File(*.jpeg)|*.jpeg| JPG File (*.jpg)|*.jpg| Bitmap File (*.bmp)|*.bmp| PNG File (*.png)|*.png ";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ChoosedFile = dlg.FileName;
                    pictureBox1.Image = Image.FromFile(ChoosedFile);
                }
            }
        }

        private void PictureBox1(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                //String Choosedfile;
                dlg.Title = "Open Image";
                dlg.Filter = "All Images (*.jpeg , *.jpg , *.bmp , *.png)| *.jpeg;*.jpg;*.bmp;*.png| JPEG File(*.jpeg)|*.jpeg| JPG File (*.jpg)|*.jpg| Bitmap File (*.bmp)|*.bmp| PNG File (*.png)|*.png ";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ChoosedFile = dlg.FileName;
                    pictureBox1.Image = Image.FromFile(ChoosedFile);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

       
        
    }

}

      
