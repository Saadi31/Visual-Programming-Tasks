using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Watermark
{
    public partial class Form4 : Form
    {
        string EnteredText2;
        InstalledFontCollection fonts = new InstalledFontCollection();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Form2 frm = new Form2();
            //frm.Show();
           // this.Hide();

          

            FontFamily[] font = fonts.Families.ToArray();

            for (int i = 0; i < font.Length; i++)
            {

                comboBox2.Items.Add(font[i].Name);

            }          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnteredText2 = textBox1.Text;
                MessageBox.Show(EnteredText2);
            }
        }


         public void Backbtn(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            button1.Hide();
            this.Hide();
            frm1.Show(); 
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
        }
    }
}
