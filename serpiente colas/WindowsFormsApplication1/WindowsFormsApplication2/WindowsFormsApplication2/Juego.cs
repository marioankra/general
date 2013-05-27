using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Juego : Entrenamiento.OnPingListener
    {

        private Entrenamiento entrenamiento;
        private Multi multi;
        private Individual individual;
        private Interface1 juegoActual;
        private int _modo;
        private int _tamaño = 20;

        Brush _cSerpiente = Brushes.Green;
        Brush _cTablero = Brushes.Red;
        Brush _cComida = Brushes.Blue;



        public void onColor(bool estaMarcado) { 
          
            if (!estaMarcado)
                _cComida = Brushes.Blue;
            else
            _cComida = Brushes.Black;

        }
        
        public  Juego(int tipo, int opcion) {
            entrenamiento=null;
            multi=null;
            individual=null;

            _modo = tipo;
            switch (_modo)
            {
                case 1:
                    entrenamiento = new Entrenamiento(_tamaño, opcion,this);
                  
                    juegoActual = entrenamiento;
                   
                    break;
               case 2:
                   individual =  new Individual(_tamaño, opcion);
                  
                    juegoActual = individual;
                   
                    break;
                 case 3:
                multi = new Multi(_tamaño, opcion);
                  
                    juegoActual = multi;
                  
                    break;


          }
        
        }

        public Brush CSerpiente
        {
            get { return _cSerpiente; }
            
        }

        public Brush CTablero
        {
            get { return _cTablero; }

        }

        public Brush CComida
        {
            get { return _cComida; }

        }

        public int  Player {set { juegoActual.setPlayer(value); } }
        public Queue Tablero { get { return juegoActual.getTablero(); } }
        public Queue Serpiente { get { return juegoActual.getSerpiente(); } }


        public int Objetivo { get { return juegoActual.getObjetivo(); } }
        public int Puntos { get { return juegoActual.getPuntuacion(); } }
        
        public int Direccion {  set { juegoActual.setDir(value); } }
        public int Tamaño { get { return _tamaño; } }
        public int[] Comida { get { return juegoActual.getComida(); } }
        public int cantidadComida { get { return juegoActual.getCantidadComida(); } }
        
        public Boolean Fin
        {
            get { return juegoActual.getHayFin(); }
            set { juegoActual.setHayFin(value); } 
        }

    }
}
