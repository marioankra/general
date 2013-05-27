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

        int _opcion = 0;
        int _tablero = 0;
        public Form1()
        {
            InitializeComponent();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
           
            Form2 frm = new Form2(1,(int)numericUpDownSelectLvl.Value);
            frm.ShowDialog();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(2,_opcion);
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(3, _opcion);
            frm.ShowDialog();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (_opcion == 0) _opcion = 1;

            else
                _opcion = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (_tablero == 0) _tablero = 1;

            else
                _tablero = 0;
        }

   


      

        

    }
}
