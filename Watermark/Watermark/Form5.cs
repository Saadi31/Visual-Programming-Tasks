using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
namespace Watermark
{
    public partial class Form5 : Form
    {
        Point dragPoint;
        bool dragging;
        
        public Form5()
        {
            InitializeComponent();

            myWatermarkColor = Color.SteelBlue;
            comboBoxOpacity.SelectedIndex = 2;
            rdTop.Checked = true;
           // txtboxWaterMark.Text = "Your Name " + char.ConvertFromUtf32(169).ToString() + " " +
          //  DateTime.Now.Year.ToString() + ", All Rights Reserved";
            txtboxWaterMark.Text = "";
            myFont = txtboxWaterMark.Font;

          
        }

        string CurrentFile;
        Image img;
        System.Drawing.Color myWatermarkColor;
        System.Drawing.Font myFont;



        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Filter Common Usable Formats
            openFileDialog1.Title = "Open Image File";
            openFileDialog1.Filter = "Bitmap Files|*.bmp" +
                "|Enhanced Windows MetaFile|*.emf" +
                "|Exchangeable Image File|*.exif" +
                "|Gif Files|*.gif|JPEG Files|*.jpg" +
                "|PNG Files|*.png|TIFF Files|*.tif|Windows MetaFile|*.wmf";
            openFileDialog1.DefaultExt = "";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            // If the user did not select a file, return
            if (openFileDialog1.FileName == "")
                return;

            // Update the current file and form caption text
            CurrentFile = openFileDialog1.FileName.ToString();
            this.Text = "Watermark Utility: " + CurrentFile.ToString();

            try
            {
                // Open the image into the picture box
                img = Image.FromFile(openFileDialog1.FileName, true);
                pictureBox1.Image = img;

                // Resize the picture box to support scrolling large images                
               // pictureBox1.Size = img.Size;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Open Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Default font and color applied to the textbox 
            fontDialog1.ShowColor = true;
            fontDialog1.Font = txtboxWaterMark.Font;
            fontDialog1.Color = txtboxWaterMark.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                myFont = fontDialog1.Font;
                myWatermarkColor = fontDialog1.Color;
                txtboxWaterMark.Font = fontDialog1.Font;
                txtboxWaterMark.ForeColor = fontDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Reload the image in PictureBox
            pictureBox1.Image = Image.FromFile(CurrentFile);

            int opac = 0;
            string sOpacity = comboBoxOpacity.Text;

            // Set the opacity level
            switch (sOpacity)
            {
                case "100%":
                    opac = 255; // 1 * 255
                    break;
                case "75%":
                    opac = 191; // .75 * 255
                    break;
                case "50%":
                    opac = 127; // .5 * 255
                    break;
                case "25%":
                    opac = 64;  // .25 * 255
                    break;
                case "10%":
                    opac = 25;  // .10 * 255
                    break;
                default:
                    opac = 127; // default at 50%; .5 * 255
                    break;
            }

            // Get a graphics context
            Graphics g = Graphics.FromImage(pictureBox1.Image);

            // Create a solid brush to write the watermark text on the image
            Brush myBrush = new SolidBrush(Color.FromArgb(opac, myWatermarkColor));

            // Calculate the size of the text
            SizeF sz = g.MeasureString(txtboxWaterMark.Text, myFont);

            // drawing position (X,Y)
            int X;
            int Y;

            //Set the drawing position based on the users
            //selection of placing the text at the bottom or top of the image
            if (rdTop.Checked == true)
            {
                X = (int)(pictureBox1.Image.Width - sz.Width) / 2;
                Y = (int)(pictureBox1.Top + sz.Height) / 2;
            }
            else
            {
                X = (int)(pictureBox1.Image.Width - sz.Width) / 2;
                Y = (int)(pictureBox1.Image.Height - sz.Height);
            }

            // draw the water mark text
            g.DrawString(txtboxWaterMark.Text, myFont, myBrush, new Point(X, Y));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string strExt;
                strExt = System.IO.Path.GetExtension(CurrentFile);
                strExt = strExt.ToUpper();
                strExt = strExt.Remove(0, 1);

                // if the current image is, for example, a JPG, only
                // allow the user to save the file with the watermark
                // as a JPG
                SaveFileDialog1.Title = "Save File";
                SaveFileDialog1.DefaultExt = strExt;
                SaveFileDialog1.Filter = strExt + " Image Files|*." + strExt;
                SaveFileDialog1.FilterIndex = 1;

                if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (SaveFileDialog1.FileName == "")
                    {
                        return;
                    }
                    else
                    {
                        // save the file with the name supplied by the user
                        pictureBox1.Image.Save(SaveFileDialog1.FileName);
                    }

                    // update the current image file to point to the newly saved
                    // image
                    CurrentFile = SaveFileDialog1.FileName;
                    this.Text = "Watermark Utility: " + CurrentFile;
                    MessageBox.Show(CurrentFile.ToString() + " saved.", "File Save");
                }
                else
                {
                    MessageBox.Show("The save file request was cancelled by user.", "Save Cancelled");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Image Save Error");
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void txtboxWaterMark_MouseDown(object sender, MouseEventArgs e)
        {

            dragging = true;
            dragPoint = new Point(e.X, e.Y);
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                txtboxWaterMark.Location = new Point(txtboxWaterMark.Location.X + e.X - dragPoint.X, txtboxWaterMark.Location.Y + e.Y - dragPoint.Y);


        }

        private void label6_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }















    }
}
