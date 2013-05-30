using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Timers;

namespace WindowsFormsApplication1
{
    class Nivel
    {
        private int _objetivo;
        private int _velocidad; 
        private int _tamaño;
        private int _dificultad;
        private Tablero tablero;

        public Tablero TablerodelNivel {
            get { return tablero; }
        }
       

        public  Nivel (int dificultad, int velocidad , int objetivo,int tamaño) {
            _dificultad=dificultad;
            _objetivo = objetivo;
            _velocidad = velocidad;
            _tamaño = tamaño;
           

             tablero = new Tablero(_tamaño, _dificultad);
        
        
        }

        public bool buscarenTablero(int x, int y) {

            return tablero.buscarenTablero(x, y);
        }

        public Queue Tablero
        {
            get { return tablero.Mapa; }
          
        }

    }
}
