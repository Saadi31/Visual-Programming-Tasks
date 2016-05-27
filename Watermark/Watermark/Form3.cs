using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;



namespace Watermark
{
    public partial class Form3 : Form
    {

        //=======Variables Being Used========================
        string EnteredText1;
        string ChoosedFile;
        string watermarkimage;
        float size;
        int opacityvalue;
        float imageopacityvalue;
        string CurrentFile;
        
        
        Point dragPoint;
        bool dragging;


        System.Drawing.Font LabelFont;

        InstalledFontCollection fonts = new InstalledFontCollection();

        //======Constructor===============================================
        public Form3()
        {
            InitializeComponent();
            var pos = this.PointToScreen(label6.Location);
            pos = pictureBox1.PointToClient(pos);
            label6.Parent = pictureBox1;
            label6.Location = pos;
            label6.BackColor = Color.Transparent;

            pictureBox2.Parent = pictureBox1;
            pictureBox2.Image = null;
            
         

            dragPoint = Point.Empty;
            dragging = false;

            LabelFont = (Font)Font.Clone();


        }






        //========= Take User to Start Form=================================

        public void Backbtn(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();

            this.Hide();
            frm1.Show();

        }


       






        //========Open File From Menu Strip===============================

        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                using (OpenFileDialog dlg = new OpenFileDialog())
                {

                    dlg.Title = "Open Image";
                    dlg.Filter = "All Images (*.jpeg , *.jpg , *.bmp , *.png)| *.jpeg;*.jpg;*.bmp;*.png" +
                        "|JPEG File(*.jpeg)|*.jpeg" +
                        "|JPG File (*.jpg)|*.jpg" +
                        "|Bitmap File (*.bmp)|*.bmp" +
                        "|PNG File (*.png)|*.png " +
                        "|Enhanced Windows MetaFile(*.emf)|*.emf" +
                        "|Exchangeable Image File(*.exif)|*.exif" +
                        "|Gif Files(/.gif)|*.gif" +
                        "|TIFF Files(*.tif)|*.tif" +
                        "|Windows MetaFile(*.wmf)|*.wmf";
                    dlg.FilterIndex = 1;
                    dlg.DefaultExt = "";
                    dlg.CheckFileExists = true;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        CurrentFile = dlg.FileName.ToString();
                        this.Text = "Watermark Application" + CurrentFile.ToString();
                        ChoosedFile = dlg.FileName;
                        pictureBox1.Image = Image.FromFile(ChoosedFile);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //return null;
            }  
        }



       




        //===============Open New File from button "New Image"==========================

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                using (OpenFileDialog OFdlg = new OpenFileDialog())
                {

                    using (OpenFileDialog dlg = new OpenFileDialog())
                    {

                        dlg.Title = "Open Image";
                        dlg.Filter = "All Images (*.jpeg , *.jpg , *.bmp , *.png)| *.jpeg;*.jpg;*.bmp;*.png" +
                            "|JPEG File(*.jpeg)|*.jpeg" +
                            "|JPG File (*.jpg)|*.jpg" +
                            "|Bitmap File (*.bmp)|*.bmp" +
                            "|PNG File (*.png)|*.png " +
                            "|Enhanced Windows MetaFile(*.emf)|*.emf" +
                            "|Exchangeable Image File(*.exif)|*.exif" +
                            "|Gif Files(/.gif)|*.gif" +
                            "|TIFF Files(*.tif)|*.tif" +
                            "|Windows MetaFile(*.wmf)|*.wmf";
                        dlg.FilterIndex = 1;
                        dlg.DefaultExt = "";
                        dlg.CheckFileExists = true;
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            CurrentFile = dlg.FileName.ToString();
                            this.Text = "Watermark Application" + CurrentFile.ToString();
                            ChoosedFile = dlg.FileName;
                            pictureBox1.Image = Image.FromFile(ChoosedFile, true);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //return null;
            }  
        }









       






        // =============Save file from button "Save"================================

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (ChoosedFile == null)
                {
                    MessageBox.Show("No File to Save");
                }

                else
                {
                    SaveFileDialog SFdlg = new SaveFileDialog();

                    SFdlg.Title = "Save File As";
                    SFdlg.Filter = "All Images (*.jpeg , *.jpg , *.bmp , *.png)| *.jpeg;*.jpg;*.bmp;*.png" +
                        "|JPEG File(*.jpeg)|*.jpeg" +
                        "|JPG File (*.jpg)|*.jpg" +
                        "|Bitmap File (*.bmp)|*.bmp" +
                        "|PNG File (*.png)|*.png " +
                        "|Enhanced Windows MetaFile(*.emf)|*.emf" +
                        "|Exchangeable Image File(*.exif)|*.exif" +
                        "|Gif Files(/.gif)|*.gif" +
                        "|TIFF Files(*.tif)|*.tif" +
                        "|Windows MetaFile(*.wmf)|*.wmf";

                    SFdlg.FilterIndex = 1;

                    SFdlg.OverwritePrompt = true;
                    SFdlg.CheckPathExists = true;
                    SFdlg.RestoreDirectory = true;

                    SFdlg.ShowDialog();

                    if (SFdlg.FileName != "") // && SFdlg.ShowDialog() == DialogResult.OK ) // && SFdlg.ShowDialog() != DialogResult.Cancel)
                    {

                        System.IO.FileStream fs = (System.IO.FileStream)SFdlg.OpenFile();

                        switch (SFdlg.FilterIndex)
                        {
                            case 1:
                                pictureBox1.Image.Save(fs,
                                  System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;

                            case 2:
                                pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;

                            case 3:
                                pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Bmp);
                                break;

                            case 4:
                                pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }

                        fs.Close();


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //return null;
            }  
        }

      //===============Save file From Menu button "Save"==============================

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChoosedFile == null)
                {
                    MessageBox.Show("No File to Save");
                }

                else
                {
                    SaveFileDialog SFdlg = new SaveFileDialog();

                    SFdlg.Title = "Save File As";
                    SFdlg.Filter = "All Images (*.jpeg , *.jpg , *.bmp , *.png)| *.jpeg;*.jpg;*.bmp;*.png" +
                        "|JPEG File(*.jpeg)|*.jpeg" +
                        "|JPG File (*.jpg)|*.jpg" +
                        "|Bitmap File (*.bmp)|*.bmp" +
                        "|PNG File (*.png)|*.png " +
                        "|Enhanced Windows MetaFile(*.emf)|*.emf" +
                        "|Exchangeable Image File(*.exif)|*.exif" +
                        "|Gif Files(/.gif)|*.gif" +
                        "|TIFF Files(*.tif)|*.tif" +
                        "|Windows MetaFile(*.wmf)|*.wmf";

                    SFdlg.FilterIndex = 1;

                    SFdlg.OverwritePrompt = true;
                    SFdlg.CheckPathExists = true;
                    SFdlg.RestoreDirectory = true;

                    SFdlg.ShowDialog();

                    if (SFdlg.FileName != "") // && SFdlg.ShowDialog() == DialogResult.OK ) // && SFdlg.ShowDialog() != DialogResult.Cancel)
                    {

                        System.IO.FileStream fs = (System.IO.FileStream)SFdlg.OpenFile();

                        switch (SFdlg.FilterIndex)
                        {
                            case 1:
                                pictureBox1.Image.Save(fs,
                                  System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;

                            case 2:
                                pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;

                            case 3:
                                pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Bmp);
                                break;

                            case 4:
                                pictureBox1.Image.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }

                        fs.Close();


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //return null;
            }  

        }






        //=========Show system fonts in ComboBox2================================


        public void button4_Click(object sender, EventArgs e)
        {
            FontFamily[] font = fonts.Families.ToArray();
           
            for (int i = 0; i < font.Length; i++)
            {

                comboBox2.Items.Add(font[i].Name);
               
               // Fonty = Convert.ToString(comboBox2.SelectedItem);

            }
           

           
        }






        //============Set font of label=================================

        String FontString;

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var cvt = new FontConverter();
                FontString = Convert.ToString(comboBox2.SelectedItem);
                //comboBox2.SelectedItem = cvt.ConvertToString(this.Font);
                label6.Font = cvt.ConvertFromString(FontString) as Font;
                LabelFont = label6.Font;
                // = comboBox2.SelectedItem;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //return null;
            }  

        }
        

      



        //==========Show Text on PictureBox on pressing Enter================

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    EnteredText1 = textBox1.Text;

                    label6.Text = EnteredText1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //return null;
            }  
        }



       





        //=============Change Font Size of text===============================
        

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
          //  size = Convert.ToInt32(((NumericUpDown)sender).Text);
            size = Convert.ToInt32(numericUpDown1.Value);
            //label6.Font = size ;
            
            Font newFont = new Font(LabelFont.FontFamily, (float)numericUpDown1.Value);
            label6.Font = newFont;
            LabelFont.Dispose();
            LabelFont = newFont;

            
        }


     


        //===========Set Opacity of text on scrollong trackbar=================

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            opacityvalue = trackBar1.Value;
            label6.ForeColor = Color.FromArgb(opacityvalue, r, g, b);
           

        }






       //=============Show Color Dialog=====================================

        int r;
        int g;
        int b;
        private void button4_Click_1(object sender, EventArgs e)
        {
            
            ColorDialog cdlg = new ColorDialog();
            cdlg.ShowDialog();
            Color clr = cdlg.Color;

          
            try
            {

                r = clr.R;
                g = clr.G;
                b = clr.B;
                label6.ForeColor = Color.FromArgb(opacityvalue, r, g, b);
           


            }
            catch (Exception ex)
            {
                //doing nothing
            }



           

              

            }




        //================= Draw text on Image=============================
       


        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(ChoosedFile);



                // Get a graphics context
                Graphics g = Graphics.FromImage(pictureBox1.Image);


                Brush myBrush = new SolidBrush(Color.FromArgb(opacityvalue, label6.ForeColor));




                // draw the water mark text
                g.DrawString(label6.Text, LabelFont, myBrush, new Point(label6.Location.X, label6.Location.Y));
                // g.DrawString(label6.Text, LabelFont, myBrush, new Point(label6.Location.X, label6.Location.Y));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Watermark text not entered \n Enter Watermark Text");
                //return null;
            }  

        }


       
      





        //================Exit from window========================

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }








       



        



       
        //==========================Label DRAGING TOOL=========================
        private void label6_MouseDown(object sender, MouseEventArgs e)
        {

            dragging = true;
            dragPoint = new Point(e.X, e.Y);
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                label6.Location = new Point(label6.Location.X + e.X - dragPoint.X, label6.Location.Y + e.Y - dragPoint.Y);
          

        }

        private void label6_MouseUp(object sender, MouseEventArgs e)
        {
          
            dragging = false;
            //label6.Location.X = e.X;
            //label6.Location.Y = e.Y;
        }






       

       
       


        //==================Load Watermark Image=======================================

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                using (OpenFileDialog dlg = new OpenFileDialog())
                {

                    dlg.Title = "Open Image";
                    dlg.Filter = "All Images (*.jpeg , *.jpg , *.bmp , *.png)| *.jpeg;*.jpg;*.bmp;*.png" +
                        "|JPEG File(*.jpeg)|*.jpeg" +
                        "|JPG File (*.jpg)|*.jpg" +
                        "|Bitmap File (*.bmp)|*.bmp" +
                        "|PNG File (*.png)|*.png " +
                        "|Enhanced Windows MetaFile(*.emf)|*.emf" +
                        "|Exchangeable Image File(*.exif)|*.exif" +
                        "|Gif Files(/.gif)|*.gif" +
                        "|TIFF Files(*.tif)|*.tif" +
                        "|Windows MetaFile(*.wmf)|*.wmf";
                    dlg.FilterIndex = 1;
                    dlg.DefaultExt = "";
                    dlg.CheckFileExists = true;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        CurrentFile = dlg.FileName.ToString();
                        this.Text = "Watermark Application" + CurrentFile.ToString();
                        watermarkimage = dlg.FileName;
                        pictureBox2.Image = Image.FromFile(watermarkimage);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //return null;
            }  
        }




        //=====================picture draging================================

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragPoint = new Point(e.X, e.Y);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {

            if (dragging)
                pictureBox2.Location = new Point(pictureBox2.Location.X + e.X - dragPoint.X, pictureBox2.Location.Y + e.Y - dragPoint.Y);
           
            

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            
            dragging = false;
        
        }

       




         //============= hiding text watermark label=============================
        private void tabPage1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null ;
            //label6.Text = "";
        }

        private void tabPage2_MouseClick(object sender, MouseEventArgs e)
        {
            label6.Text = null;
        }






        //==============Track bar to set the opacity of the image========================

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            imageopacityvalue = trackBar2.Value;
        }


    //================= Draw Image ====================================
        private void button9_Click(object sender, EventArgs e)
        {
            
            try
            {

                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(pictureBox2.Image.Width, pictureBox2.Image.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(pictureBox1.Image))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = imageopacityvalue;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(pictureBox2.Image, new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, bmp.Width, bmp.Height), 0, 0, pictureBox2.Image.Width, pictureBox2.Image.Height, GraphicsUnit.Pixel, attributes);
                }
                //return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Watermark Image not loaded \n Add watermark image.");
                //return null;
            }    

        }


        //private void ControlPaintEventHandler(object sender, PaintEventArgs e)
        //{


           
        
        //}


        public  Bitmap ChangeOpacity(Image img, float opacityvaluex)
        {
            img = pictureBox1.Image;
            opacityvaluex = imageopacityvalue;
            Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();

            colormatrix.Matrix33 = opacityvaluex;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }





        Font f;
        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
           // fontex = new Font(font[comboBox2.SelectedIndex].Name, size);

            var cvt = new FontConverter();
            string s = cvt.ConvertToString(comboBox2.SelectedItem);

            f = cvt.ConvertFromString(s) as Font;
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                label6.Font = new Font(label6.Font, FontStyle.Bold);   
            else if (checkBox1.Checked == true && checkBox2.Checked == true)
                label6.Font = new Font(label6.Font, FontStyle.Bold | FontStyle.Italic);
            else if (checkBox1.Checked == true && checkBox3.Checked == true)
                label6.Font = new Font(label6.Font, FontStyle.Bold | FontStyle.Underline);
            else if(checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                label6.Font = new Font(label6.Font, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            else
                        label6.Font = new Font(label6.Font, FontStyle.Regular);
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                label6.Font = new Font(label6.Font, FontStyle.Italic);
            else if (checkBox2.Checked == true && checkBox3.Checked == true)
                label6.Font = new Font(label6.Font, FontStyle.Bold | FontStyle.Underline);
            else if (checkBox2.Checked == true && checkBox1.Checked == true)
                label6.Font = new Font(label6.Font, FontStyle.Bold | FontStyle.Italic);
            else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                label6.Font = new Font(label6.Font, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            else 
                label6.Font = new Font(label6.Font, FontStyle.Regular);

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                label6.Font = new Font(label6.Font, FontStyle.Underline);
            else if (checkBox1.Checked == true && checkBox3.Checked == true)
                label6.Font = new Font(label6.Font, FontStyle.Bold | FontStyle.Underline);
            else if (checkBox2.Checked == true && checkBox3.Checked == true)
                label6.Font = new Font(label6.Font, FontStyle.Italic | FontStyle.Underline);
            else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                label6.Font = new Font(label6.Font, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            else
                label6.Font = new Font(label6.Font, FontStyle.Regular);
        }







      






      

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            label6.Text = null;
            textBox1.Text = null;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
           // label6.Text = null;
        }

       

       
      

       
    
    
    
    
    
 }







        //==============Temporary Image Button===========================
       

        

      

       

        


       

       

       

       

      
        //==================================================================
        //==================================================================





       

        

       
       

     





    
      
        



    }


   



   