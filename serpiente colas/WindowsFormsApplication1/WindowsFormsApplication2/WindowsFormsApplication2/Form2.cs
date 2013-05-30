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
        private int _modo;
        Nodo n;


        public Form2(int modo, int opcion,int nivel)
        {
            _modo = modo;
            InitializeComponent();
            partida = new Juego(modo, opcion,nivel);
            
            

            timer1.Interval = 50;
            timer1.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
           // textBox1.Text = partida.Puntos.ToString();



            switch (_modo)
            {
                case 1:

                    label1.Text = "Puntuación: " + partida.Puntos.ToString() + " Objetivo: " + partida.Objetivo.ToString();
                    break;
                case 2:
                    label1.Text = "Puntuación: " + partida.Puntos.ToString();
                    break;
            }


           // textBox2.Text = partida.Objetivo.ToString();
        }

    
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            _coordenadas = new int[2];
            escala = pictureBox1.Width / partida.Tamaño;
            Graphics lienzo;
            lienzo = e.Graphics;
            _coordenadas = partida.Comida;
           

            System.Collections.IEnumerator ent = partida.Tablero.GetEnumerator();
            partida.Player = 0;
            System.Collections.IEnumerator ens = partida.Serpiente.GetEnumerator();

            while (ens.MoveNext())
            {
                n = (Nodo)ens.Current;
                lienzo.FillRectangle(partida.CSerpiente, n.X * escala, n.Y * escala, escala, escala);

            }

            while (ent.MoveNext())
            {
              
                _coordenadas = (int[])ent.Current;
                lienzo.FillRectangle(partida.CTablero, _coordenadas[0] * escala, _coordenadas[1] * escala, escala, escala);

            }


            partida.Player = 1;
            ens = partida.Serpiente.GetEnumerator();
            while (ens.MoveNext())
            {
                n = (Nodo)ens.Current;
                lienzo.FillRectangle(partida.CSerpiente, n.X * escala, n.Y * escala, escala, escala);

            }


            _coordenadas = partida.Comida;
            lienzo.FillRectangle(partida.CComida, _coordenadas[0] * escala, _coordenadas[1] * escala, escala, escala);
            lienzo.DrawString(partida.cantidadComida.ToString(), new Font("Arial", 12), Brushes.Yellow, _coordenadas[0] * escala, _coordenadas[1] * escala);




            if (partida.Fin)
                lienzo.DrawString("GAME OVER", new Font("Arial", 12), Brushes.Yellow, 1, 1);
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                partida.Player = 0;
                partida.Direccion = 3;
            }

            if (e.KeyData == Keys.D)
            {
                partida.Player = 0;
                partida.Direccion = 0;
            }

            if (e.KeyData == Keys.S)
            {
                partida.Player = 0;
                partida.Direccion = 1;
            }

            
            if (e.KeyData == Keys.A)
            {
                partida.Player = 0;
                partida.Direccion = 2;
            }
            if (partida.Player ==2)
            {
            if (e.KeyData == Keys.I)
            {
                partida.Player = 1;
                partida.Direccion = 3;
            }

            if (e.KeyData == Keys.L)
            {
                partida.Player = 1;
                partida.Direccion = 0;
            }

            if (e.KeyData == Keys.K)
            {
                partida.Player = 1;
                partida.Direccion = 1;
            }


            if (e.KeyData == Keys.J)
            {
                partida.Player = 1;
                partida.Direccion = 2;
            }
        }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    

    
    }
}
