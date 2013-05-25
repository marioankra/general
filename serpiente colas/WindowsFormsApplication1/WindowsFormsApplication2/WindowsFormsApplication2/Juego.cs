using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    class Juego
    {

        private Entrenamiento entrenamiento;
        private Entrenamiento competicion;
        private Entrenamiento individual;
        private Interface1 juegoActual;
        private int _modo;
        private int _tamaño = 20;
        
        
        public void generarModo(int tipo) {
            entrenamiento=null;
            competicion=null;
            individual=null;

            _modo = tipo;
            switch (_modo)
            {
                case 1:
                    entrenamiento = new Entrenamiento(_tamaño);
                    juegoActual = entrenamiento;
                   
                    break;
                /*case 2:
                    Console.WriteLine("Case 2");
                    break;
               case 3 :
                    Console.WriteLine("Default case");
                    break;
*/            }
        
        }




      


        public Queue Tablero { get { return juegoActual.getTablero(); } }
        public Queue Serpiente { get { return juegoActual.getSerpiente(); } }
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
