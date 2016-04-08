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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     

        private void label1_Click(object sender, EventArgs e)
        {
           
        



        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }


    public partial class Form3 : Form
    {
        public Form3()
        {
            Text = "Form 3";
        }
    }
}
