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
    public partial class Form2 : Form
    {

        private int escala;
        private Juego partida;
        private int[] _coordenadas;
     
        Nodo n;


        public Form2(int modo)
        {
            InitializeComponent();
            partida = new Juego();
            partida.generarModo(modo);
            

            timer1.Interval = 50;
            timer1.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            _coordenadas = new int[2];
            escala = pictureBox1.Width / partida.Tamaño;
            Graphics lienzo;
            lienzo = e.Graphics;
            _coordenadas = partida.Comida;



            System.Collections.IEnumerator ent = partida.Tablero.GetEnumerator();
            System.Collections.IEnumerator ens = partida.Serpiente.GetEnumerator();
            while (ent.MoveNext())
            {

                _coordenadas = (int[])ent.Current;
                lienzo.FillRectangle(Brushes.Red, _coordenadas[0] * escala, _coordenadas[1] * escala, escala, escala);

            }

            while (ens.MoveNext())
            {
                n = (Nodo)ens.Current;
                lienzo.FillRectangle(Brushes.Green, n.X * escala, n.Y * escala, escala, escala);

            }


            _coordenadas = partida.Comida;
            lienzo.FillRectangle(Brushes.Blue, _coordenadas[0] * escala, _coordenadas[1] * escala, escala, escala);
            lienzo.DrawString(partida.cantidadComida.ToString(), new Font("Arial", 12), Brushes.Yellow, _coordenadas[0] * escala, _coordenadas[1] * escala);




            if (partida.Fin)
                lienzo.DrawString("GAME OVER", new Font("Arial", 12), Brushes.Yellow, 1, 1);
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                partida.Direccion = 3;
            }

            if (e.KeyData == Keys.D)
            {
                partida.Direccion = 0;
            }

            if (e.KeyData == Keys.S)
            {
                partida.Direccion = 1;
            }


            if (e.KeyData == Keys.A)
            {
                partida.Direccion = 2;
            }
        }
    }
}
