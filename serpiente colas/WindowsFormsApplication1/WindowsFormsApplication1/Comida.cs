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
        private int _marca = 3;
        private int _x, _y;
        private int _cantidad;
        private Timer timerPosicion;
        private OnPingListener mListener;
        public interface OnPingListener
        {
            void onPing();
            void onColor();
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

        public Comida(Queue tablero, Queue serpiente, int tamaño,int sx, int sy)
        {
            timerPosicion = new Timer();
            Random r = new Random(DateTime.Now.Millisecond);
            generarCoordenadasComida(tablero,serpiente,tamaño,sx,sy); 
            _cantidad = r.Next(1, 5);
            timerPosicion.Elapsed += new ElapsedEventHandler(timerPosicion_tick);
            timerPosicion.
            timerPosicion.Enabled = true;
            timerPosicion.Interval = 2000;

        }


        public int X
        {
            get { return _x; }
            set { _x = value; }
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

        public void generarCoordenadasComida (Queue tablero, Queue serpiente, int tamaño,int sx, int sy)
        {
            System.Collections.IEnumerator ent = tablero.GetEnumerator();
            System.Collections.IEnumerator ens = serpiente.GetEnumerator();
            
            Random r = new Random(DateTime.Now.Millisecond);
            int[] coordenadas= new int[2];
            Nodo n;
            Boolean estaEnTablero;
            Boolean estaEnSerpiente;

            do
            {
                estaEnTablero = false;
                estaEnSerpiente = false;
                _x = r.Next(1, tamaño-1);
                _y = r.Next(1, tamaño-1);
                
                if (_x== sx && _y == sy)
                    estaEnSerpiente = true;
                else
                    estaEnSerpiente = false;

                while (ent.MoveNext()  && !estaEnTablero) {
                    coordenadas = (int[])ent.Current;
                    if (coordenadas[0] == _x && coordenadas[1] == _y)
                        estaEnTablero = true;
                    else
                        estaEnTablero = false;
                }
               
                while (ens.MoveNext() && !estaEnSerpiente)
                {
                    n = (Nodo)ens.Current;
                    if (n.X == _x && n.Y == _y)
                        estaEnSerpiente = true;
                    else
                        estaEnSerpiente = false;
                }   

            } while (estaEnSerpiente || estaEnTablero);


}
        


        private void timerPosicion_tick(object source, ElapsedEventArgs e)
        {
            mListener.onPing();
            if (_marca == 0) mListener.onColor();
            else _marca--;
        }
     
    }
}
