using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        int _modo = 0;
        public Form1()
        {
            InitializeComponent();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
           
            Form2 frm = new Form2(1,(int)numericUpDown1.Value);
            frm.ShowDialog();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

      

        

    }
}
