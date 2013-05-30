

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Timers;




namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //Tamaño es el numero de nodos que entran  en el tablero y escala el numero de pixeles de cada uno
        //coordendadas es un array temporal
         private int escala;
        private Juego partida ;
        private int[] _coordenadas;
        private PictureBox pictureBox1;
        Nodo n;

        public Form1()
        
        {
            InitializeComponent();
             partida = new Juego();


             timer1.Interval = 50;
        }

        // p pausa el juego y n crea una nueva partida, los movimientos se generan con las teclas de direccion
        private void Form1_Key(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.W)
            {
                partida.Direccion=3;
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
        //pinta el picturebox con la serpiente, el tablero o la comida
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            _coordenadas=new int[2];
            escala = pictureBox1.Width / partida.Tamaño;
            Graphics lienzo;
            lienzo = e.Graphics; 
            _coordenadas= partida.Comida;
            
           
            
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                    pictureBox1.Refresh();
            if (partida.Fin == true) timer1.Stop();
        }

        private void entrenamiento_Click(object sender, EventArgs e)
        {
            pictureBox1 = new PictureBox();
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(300, 300);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            partida.generarModo(1);
            timer1.Start();
         
        }

    



    }
}
