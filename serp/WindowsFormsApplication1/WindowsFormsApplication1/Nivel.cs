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


       

        public  Nivel (int dificultad, int velocidad , int objetivo,int tamaño) {
            dificultad=_dificultad;
            objetivo = _objetivo;
            velocidad = _velocidad;
            tamaño = _tamaño;
           

             tablero = new Tablero(_tamaño, _dificultad);
        
        
        }


        public Queue Tablero
        {
            get { return tablero.Mapa; }
          
        }

    }
}
