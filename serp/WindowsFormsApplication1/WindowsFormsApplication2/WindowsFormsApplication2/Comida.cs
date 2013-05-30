using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Timers;
namespace WindowsFormsApplication1
{
    class Comida
    {
        /// <summary>
        /// Clase que gestiona la comida de la serpiente
        ///esta clase esta relacionada con juego y solo existe una
        /// "cantidad" muestra el numero de nodos que la serpiente debera crecer
        /// </summary>
        /// 
        private int _x, _y;
        private int _cantidad;
        private Timer timerPosicion;
        private bool _estaSenyal=false;


        private OnPingListener mListener;
        public interface OnPingListener
        {
            void onPing();
           
        }
        public void setOnPingListener(OnPingListener listener)
        {
            mListener = listener;
        }
   
       
       /*El constructor genera dos coordenadas y busca si estan ocupadas si no genera en ellas la comida, si estan ocupadas genera otras y vuelve a buscarlas
        * sx e sy son la posicion de la cabeza serpiente
        *La cantidad de comida se genera de forma aleatoria entre 0 y 5  
      * Para la busqueda en las colas serpiente y tablero se usan iteradores
        */

        public Comida(int  x, int y)
        {
            _x=x;
            _y = y;
            timerPosicion = new Timer();
            Random r = new Random(DateTime.Now.Millisecond);        
            _cantidad = r.Next(1, 5);
            timerPosicion.Elapsed += new ElapsedEventHandler(timerPosicion_tick);
            timerPosicion.Enabled = true;
            timerPosicion.Interval = 7000;

        }


        public int X
        {
            get { return _x; }
            set { _x= value; }
        }


        public bool EstaSenyal
        {
            get { return _estaSenyal; }
            set { _estaSenyal = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
         
        }

        public int Cantidad {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public void pararTimer()
        {
            timerPosicion.Stop();

        }

   
        private void timerPosicion_tick(object source, ElapsedEventArgs e)
        {
            mListener.onPing();
        
        }


        public bool buscarenComida(int x, int y)
        {
            if (x == _x && y == _y)
                return true;
            else
                return false;
        }



    }
}
