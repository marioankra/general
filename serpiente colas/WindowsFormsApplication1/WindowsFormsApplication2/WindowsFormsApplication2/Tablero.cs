using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApplication1
{
    class Tablero
    {

        /// <summary>
        /// Clase tablero que genera la cola donde almacena los puntos donde (Podria usarse Nodos para almacenar los puntos pero se usan arrays de pares)
        /// Se relaciona con juego  en 1 a 1
        /// 
        /// </summary>
        private Queue _mapa;
        private int _tamaño;
        private int _numpuntos=15;
        public Tablero(int tamaño, int dificultad)
        {
            _tamaño = tamaño;
            _mapa = new Queue();

            generarNivel(dificultad);
        }

        public Queue Mapa
        {
            get { return _mapa; }

        }




        //Genera las paredes bases 
        public void generarNivel(int dificultad)
        {




            switch (dificultad)
            {
                case 0:
                    generarBase();
                   

                    break;
                case 1:
                   generarBase();
                   generarPuntos(_numpuntos * dificultad);

                    break;

                case 2:
                    generarBase();
                    generarPuntos(_numpuntos * dificultad);
                   

                    break;
                case 3:
                    generarBase();
                    generarPuntos(_numpuntos * dificultad);
                   
                    break;
                    

            }
        }


        private void generarBase()
        {
            int[] coordenadas = new int[2];

        
            _mapa.Enqueue(coordenadas);
            for (int i = 0; i < _tamaño; i++)
            {
                for (int j = 0; j < _tamaño; j++)
                {//ÑAPA
                    if (j == 0 || i == 0 || j == _tamaño - 1 || i == _tamaño - 1)
                    {
                        coordenadas = new int[2];
                        coordenadas[0] = i;
                        coordenadas[1] = j;
                        _mapa.Enqueue(coordenadas);
                    }
                }
            }

        }

        private void generarPuntos(int cantidad)
        {
           
            int[] coordenadas = new int[2];
            Random r = new Random(DateTime.Now.Millisecond);

            while (cantidad != 0)
            {
                coordenadas = new int[2];
                coordenadas[0] = r.Next(2, _tamaño - 1);
                coordenadas[1] = r.Next(2, _tamaño - 1);
                _mapa.Enqueue(coordenadas);
                cantidad--;
            }

        }

        public bool buscarenTablero(int x, int y) {
            bool estaTablero = false;
            int[] coordenadas;
            System.Collections.IEnumerator ent = _mapa.GetEnumerator();
            while (ent.MoveNext() && !estaTablero)
            {
                coordenadas = (int[])ent.Current;
                if (coordenadas[0] == x && coordenadas[1] == y)
                    estaTablero = true;
               }
            return estaTablero;
        }
       

       
    }


}