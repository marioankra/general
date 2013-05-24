using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Nivel
    {
        private int _objetivo;
        private int _velocidad; 
        private int _tamaño;
        private int dificultad;
        private Boolean _nuevoTablero;




        public  Nivel (int objetivo, int velocidad, int tamaño, int dificultad, Boolean nuevoTablero) {

            objetivo = _objetivo;
            velocidad = _velocidad;
            tamaño = _tamaño;
            nuevoTablero = _nuevoTablero;


            Tablero tablero = new Tablero(_tamaño);
        
        
        }




    }
}
