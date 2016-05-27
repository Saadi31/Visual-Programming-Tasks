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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

     

       

        private void button1_Click_1(object sender, EventArgs e)
        {

           // Form2 frm = new Form2();
          //  frm.Show();
            button1.Hide();
            
            button2.Show();
          //  button3.Show();
           // button4.Show();
          


        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
             this.Hide();
             

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
             this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

       

       
    }


   
}
